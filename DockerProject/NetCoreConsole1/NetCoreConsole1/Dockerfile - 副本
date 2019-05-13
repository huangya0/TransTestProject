FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY NetCoreConsole1/NetCoreConsole1.csproj NetCoreConsole1/
RUN dotnet restore NetCoreConsole1/NetCoreConsole1.csproj
COPY . .
WORKDIR /src/NetCoreConsole1
RUN dotnet build NetCoreConsole1.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish NetCoreConsole1.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NetCoreConsole1.dll"]
