FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["DesafioTecnicoMercado_back.csproj", "./"]
RUN dotnet restore "./DesafioTecnicoMercado_back.csproj"
COPY . .
RUN dotnet build "DesafioTecnicoMercado_back.csproj" -c Release -o /app/build
RUN dotnet publish "DesafioTecnicoMercado_back.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DesafioTecnicoMercado_back.dll"]
