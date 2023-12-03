FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HeroesOfApi.Api/HeroesOfApi.Api.csproj", "HeroesOfApi.Api/"]
RUN dotnet restore "HeroesOfApi.Api/HeroesOfApi.Api.csproj"
COPY . .
WORKDIR "/src/HeroesOfApi.Api"
RUN dotnet build "HeroesOfApi.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HeroesOfApi.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HeroesOfApi.Api.dll"]
