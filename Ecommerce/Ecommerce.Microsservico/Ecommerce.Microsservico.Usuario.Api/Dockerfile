FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Ecommerce.Microsservico/Ecommerce.Microsservico.Usuario.Api/Ecommerce.Microsservico.Usuario.Api.csproj", "Ecommerce.Microsservico/Ecommerce.Microsservico.Usuario.Api/"]
COPY ["Ecommerce.Microsservico/Ecommerce.Microsservico.Usuario.DbMigrator/Ecommerce.Microsservico.Usuario.DbMigrator.csproj", "Ecommerce.Microsservico/Ecommerce.Microsservico.Usuario.DbMigrator/"]
COPY ["Ecommerce.Commons/Ecommerce.Commons.csproj", "Ecommerce.Commons/"]
RUN dotnet restore "./Ecommerce.Microsservico/Ecommerce.Microsservico.Usuario.Api/Ecommerce.Microsservico.Usuario.Api.csproj"
COPY . .
WORKDIR "/src/Ecommerce.Microsservico/Ecommerce.Microsservico.Usuario.Api"
RUN dotnet build "./Ecommerce.Microsservico.Usuario.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ecommerce.Microsservico.Usuario.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS migrations
WORKDIR /app
COPY --from=publish /app/publish .
RUN dotnet ef database update --project /app/Ecommerce.Microsservico.Usuario.Api.dll --startup-project /app/Ecommerce.Microsservico.Usuario.Api.dll

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce.Microsservico.Usuario.Api.dll"]