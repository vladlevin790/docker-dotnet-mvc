FROM mcr.microsoft.com/dotnet/sdk:8.0 as base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /src
COPY ["app/app.csproj", "."]
RUN dotnet restore "./app.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./app/app.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "./app/app.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish/ .
ENTRYPOINT [ "dotnet", "app.dll" ]