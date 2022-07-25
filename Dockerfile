FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyCoreApi.csproj", "./"]
RUN dotnet restore "MyCoreApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MyCoreApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyCoreApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyCoreApi.dll"]
