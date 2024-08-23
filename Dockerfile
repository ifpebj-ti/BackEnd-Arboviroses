# Use the official .NET 8.0 SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy the .csproj files and restore dependencies
COPY *.sln ./
COPY arbovirose.Domain/*.csproj ./arbovirose.Domain/
COPY arbovirose.Application/*.csproj ./arbovirose.Application/
COPY arbovirose.Infra/*.csproj ./arbovirose.Infra/
COPY arbovirose.WebApi/*.csproj ./arbovirose.WebApi/

RUN dotnet restore ./arbovirose.WebApi/arbovirose.WebApi.csproj

# Copy the remaining source code and build the project
COPY . ./
RUN dotnet publish ./arbovirose.WebApi/arbovirose.WebApi.csproj -c Release -o out

# Use the official .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expose the port your application runs on
EXPOSE 80

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "arbovirose.WebApi.dll"]
