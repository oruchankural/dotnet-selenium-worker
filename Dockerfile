FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/runtime:7.0-alpine AS runtime

WORKDIR /app
COPY --from=build /app/out ./

CMD ["dotnet", "dotnet_selenium_worker.dll"]
