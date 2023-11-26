FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MinimalEndpointsTemplate/MinimalEndpointsTemplate.csproj", "MinimalEndpointsTemplate/"]
RUN dotnet restore "MinimalEndpointsTemplate/MinimalEndpointsTemplate.csproj"
COPY . .
WORKDIR "/src/MinimalEndpointsTemplate"
RUN dotnet build "MinimalEndpointsTemplate.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MinimalEndpointsTemplate.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MinimalEndpointsTemplate.dll"]
