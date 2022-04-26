FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /source

COPY src/ .

RUN dotnet publish Andtech.Famehall/Andtech.Famehall.csproj -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
RUN rm /app/appsettings.Development.json

EXPOSE 5000
#ENTRYPOINT ["/app/Andtech.Famehall"]