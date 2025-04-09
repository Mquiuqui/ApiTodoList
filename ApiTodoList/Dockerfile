FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /ApiTodoList/app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /ApiTodoList/src

COPY . .

RUN dotnet restore
RUN dotnet publish -c Release -o /ApiTodoList/app/publish

FROM base AS final
WORKDIR /ApiTodoList/app
COPY --from=build /ApiTodoList/app/publish .
ENTRYPOINT ["dotnet", "ApiTodoList.dll"]
