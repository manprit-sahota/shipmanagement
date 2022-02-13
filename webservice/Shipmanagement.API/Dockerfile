FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["webservice/Shipmanagement.API/Shipmanagement.API.csproj", "webservice/Shipmanagement.API/"]
RUN dotnet restore "webservice\Shipmanagement.API\Shipmanagement.API.csproj"
COPY . .
WORKDIR "/src/webservice/Shipmanagement.API"
RUN dotnet build "Shipmanagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shipmanagement.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shipmanagement.API.dll"]
