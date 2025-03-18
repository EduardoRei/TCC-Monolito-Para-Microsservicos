FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["Ecommerce.Microsservico/Ecommerce.Microsservico.Pedido.Api/Ecommerce.Microsservico.Pedido.Api.csproj", "Ecommerce.Microsservico/Ecommerce.Microsservico.Pedido.Api/"]
COPY ["Ecommerce.Commons/Ecommerce.Commons.csproj", "Ecommerce.Commons/"]
COPY ["Ecommerce.Microsservico/Ecommerce.Microsservico.Pedido.DbMigrator/Ecommerce.Microsservico.Pedido.DbMigrator.csproj", "Ecommerce.Microsservico/Ecommerce.Microsservico.Pedido.DbMigrator/"]
RUN dotnet restore "./Ecommerce.Microsservico/Ecommerce.Microsservico.Pedido.Api/Ecommerce.Microsservico.Pedido.Api.csproj"
COPY . .
WORKDIR "/src/Ecommerce.Microsservico/Ecommerce.Microsservico.Pedido.Api"
RUN dotnet build "Ecommerce.Microsservico.Pedido.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Fase de publicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet publish "Ecommerce.Microsservico.Pedido.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Aplicação das migrações do banco de dados antes da imagem final
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS migrations
WORKDIR /app
COPY --from=publish /app/publish .
RUN dotnet ef database update --project Ecommerce.Microsservico.Pedido.Api.dll --startup-project Ecommerce.Microsservico.Pedido.Api.dll

# Fase final: imagem otimizada para produção
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Ecommerce.Microsservico.Pedido.Api.dll"]