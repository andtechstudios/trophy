FROM mcr.microsoft.com/dotnet/core/sdk:6.0

RUN dotnet publish src/Famehall/Andtech.Famehall/Andtech.Famehall.csproj -c release -o app

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:6.0
EXPOSE 5000
ENTRYPOINT ["app/Andtech.Famehall.Server"]