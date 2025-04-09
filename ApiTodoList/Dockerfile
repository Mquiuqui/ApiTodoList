# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia apenas o .csproj primeiro
COPY *.csproj ./
RUN dotnet restore

# Copia o restante do código
COPY . .

# Publica o app
RUN dotnet publish -c Release -o /app/publish

# Etapa final de runtime
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "ApiTodoList.dll"]
