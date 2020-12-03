FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY TroydonFitnessWebsite/*.csproj ./TroydonFitnessWebsite/
RUN dotnet restore

# copy everything else and build app
COPY TroydonFitnessWebsite/. ./TroydonFitnessWebsite/
WORKDIR /app/TroydonFitnessWebsite
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=build /app/TroydonFitnessWebsite/out ./
ENTRYPOINT ["dotnet", "TroydonFitnessWebsite.dll"]
