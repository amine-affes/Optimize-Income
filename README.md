<div>
<h1 align="center">Optimize Income</h1>

<h3 align="center">This README file provides instructions for setting up the project using Git and Docker  </h3>


<p align="center">
  <a href="https://skillicons.dev">
    <img src="https://skillicons.dev/icons?i=git,docker" />
  </a>
</p>

<h3 align="center">This project built with:</h3>

<p align="center">
  <a href="https://skillicons.dev">
    <img src="https://skillicons.dev/icons?i=dotnet" />
  </a>
</p>
</div>

## Tech Stack 🛠️

**SCM:**  `Git version 2.25.1` 

**Containerization:**  `Docker version 24.0.7` 

**Server:**  `Dotnet version 8.0` 


## Prerequisites 📌

Before proceeding with the setup instructions, ensure that you have the following prerequisites installed on your system:

-  Git : Version control system for managing code repositories.

-  Docker : Containerization platform for packaging and running applications.

## Setup Instructions ⚓

Follow these steps to set up the project:

1. Clone the project repository:

```sh
$ git clone <repository_url>
```
2. Navigate to the project directory:

```sh
$ cd <repository_directory>
```

3. Update your local repository with the latest changes from the remote `main` branch:


```sh
$ git pull origin main
```

## Deployment Instructions in Development Environment ⚙️

To deploy this application in a dev environment, follow these steps:


1. Build Docker images:

```sh
$ docker build -t optimize-income-project .
```
This command uses the Dockerfile in the project root to build an image named optimize-income-project.

2. Run the Docker container:

```sh
$ docker run --rm optimize-income-project
```
The `--rm` flag removes the container after it stops, keeping your environment clean.

## Running Tests ✅

To run tests using xUnit, use the following command:

```bash
$ dotnet test
```

## Dockerfile Explanation 🐳

- Stage 1: Build Stage

``` bash

# Use the official .NET SDK image as a base image and set the working directory to /app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the current directory contents to the container at /app
COPY . .

# Publish the application
RUN dotnet publish -c Release -o out

```

In this stage, we use the official .NET SDK image as a base image, set the working directory to /app, and copy the project files into the container. Then, we use the dotnet publish command to build and publish the application, placing the output in the /app/out directory.

- Stage 2: Runtime Stage

```bash

# Build runtime image and set the working directory to /app
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app

# Copy the published output from the build stage to the runtime image
COPY --from=build /app/out .

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "Chiffre-Affaire-Project.dll"]

```
In this stage, we use the smaller .NET runtime image as a base. We set the working directory to /app, copy the published output from the build stage (using --from=build), and set the entry point to run the application.

## Docker Cheat Sheet 📑
| Task                  | Command                                 |
|-----------------------|-----------------------------------------|
| List Docker Images    | `$ docker images`                         |
| List Containers       | `$ docker ps`                             |
| Stop Container        | `$ docker stop <container_id>`            |
| Remove Image          | `$ docker rmi <image_name>`               |
| Remove Container      | `$ docker rm <container_id>`              |
| Docker Exec           | `$ docker exec -it <container_id> <command>`|
