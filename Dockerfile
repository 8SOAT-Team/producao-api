FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/Producao.Domain/Producao.Domain.csproj", "src/Producao.Domain/"]
COPY ["src/Producao.Infrastructure/Producao.Infrastructure.csproj", "src/Producao.Infrastructure/"]
COPY ["src/Producao.CrossCutting/Producao.CrossCutting.csproj", "src/Producao.CrossCutting/"]
COPY ["src/Producao.Apps/Producao.Apps.csproj", "src/Producao.Apps/"]
COPY ["src/Producao.Api/Producao.Api.csproj", "src/Producao.Api/"]
COPY ["src/Producao.Adapters/Producao.Adapters.csproj", "src/Producao.Adapters/"]

RUN dotnet restore "src/Producao.Api/Producao.Api.csproj"

COPY . .

WORKDIR "/src/src/Producao.Api"

RUN dotnet build "Producao.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Producao.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Producao.Api.dll"]
