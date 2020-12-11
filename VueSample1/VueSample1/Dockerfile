#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 8089
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY ["VueSample1/VueSample1.csproj", "VueSample1/"]
RUN dotnet restore "VueSample1/VueSample1.csproj"
COPY . .
WORKDIR "/src/VueSample1"
RUN dotnet build "VueSample1.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "VueSample1.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VueSample1.dll"]