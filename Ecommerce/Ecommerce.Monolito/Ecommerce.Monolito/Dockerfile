# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Ecommerce.Monolito/Ecommerce.Monolito/Ecommerce.Monolito.csproj", "Ecommerce.Monolito/Ecommerce.Monolito/"]
COPY ["Ecommerce.Commons/Ecommerce.Commons.csproj", "Ecommerce.Commons/"]
COPY ["Ecommerce.Monolito/Ecommerce.Migrations/Ecommerce.Monolito.DbMigrator.csproj", "Ecommerce.Monolito/Ecommerce.Migrations/"]
RUN dotnet restore "./Ecommerce.Monolito/Ecommerce.Monolito/Ecommerce.Monolito.csproj"
COPY . .
WORKDIR "/src/Ecommerce.Monolito/Ecommerce.Monolito"
RUN dotnet build "./Ecommerce.Monolito.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ecommerce.Monolito.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce.Monolito.dll"]