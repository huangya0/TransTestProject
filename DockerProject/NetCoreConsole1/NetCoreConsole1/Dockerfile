FROM microsoft/dotnet:2.1-runtime
RUN cd /usr/local/src
RUN mkdir NetCoreConsole1
WORKDIR /usr/local/src/NetCoreConsole1
COPY . .
ENTRYPOINT ["dotnet", "NetCoreConsole1.dll"]

