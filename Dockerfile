
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY App/ApiTodoList.csproj ./App/
WORKDIR /src/App
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -p:AssemblyName=ApiTodoListApp -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "ApiTodoListApp.dll"]
