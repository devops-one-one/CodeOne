FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS final
WORKDIR /app
COPY ./bin/Release/net5.0 /app/publish
ENTRYPOINT ["dotnet", "/app/publish/GymOneBackend.WebAPI.dll"]
