# Use the official .NET SDK image as a base image and set the working directory to /app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the current directory contents to the container at /app
COPY . .

# Publish the application
RUN dotnet publish -c Release -o out

# Build runtime image and set the working directory to /app
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app

# Copy the published output from the build stage to the runtime image
COPY --from=build /app/out .

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "Chiffre-Affaire-Project.dll"]
