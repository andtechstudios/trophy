# Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /source
COPY src/ ./
RUN dotnet publish Andtech.Trophy/Andtech.Trophy.csproj -c release -o /out

# Run
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /out/ ./
RUN rm /app/appsettings.Development.json

ENV AUTH_KEY=secret

EXPOSE 8080

ENTRYPOINT ["/app/Andtech.Trophy", "--urls", "http://0.0.0.0:8080"]
