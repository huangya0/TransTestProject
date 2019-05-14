FROM microsoft/dotnet:2.1-aspnetcore-runtime
RUN cd /usr/local/src
RUN mkdir MyWebAppCore
WORKDIR /usr/local/src/MyWebAppCore
COPY . .
EXPOSE 80
ENTRYPOINT ["dotnet", "MyWebAppCore.dll"]

