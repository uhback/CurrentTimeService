# Use the official .NET SDK 6 image as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# Set the working directory in the container
WORKDIR /app
# Expose the port the app will run on
EXPOSE 80
EXPOSE 443

# Copy the .csproj and restore dependencies
COPY . ./
RUN dotnet restore
# Run test
RUN dotnet test
# Build the application with release configuration
RUN dotnet publish -c Release -o out

# Use a smaller runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0
# Set the working directory to the published folder
WORKDIR /app
# Copy the published output from the build stage
COPY --from=build /app/out .

# Define the entry point for the application
ENTRYPOINT ["dotnet", "CurrentTimeService.dll"]
