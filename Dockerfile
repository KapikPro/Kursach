FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY example/*.sln .
COPY example/example/*.csproj ./example/
COPY example/example/. ./example/
RUN dotnet restore

# copy everything else and build app
WORKDIR /source/example
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "example.dll"]