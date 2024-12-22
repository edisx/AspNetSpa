FROM node:20-alpine AS react-build
WORKDIR /react-app
COPY AspNetSpa.Client/. .
RUN npm install
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY AspNetSpa.Server/. .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
COPY --from=react-build /react-app/dist/. ./wwwroot/
EXPOSE 8080
ENTRYPOINT ["dotnet", "AspNetSpa.Server.dll"]