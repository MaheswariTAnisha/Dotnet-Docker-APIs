# Use official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything and restore as distinct layers
COPY . ./
RUN dotnet restore

# Build and publish the app
RUN dotnet publish -c Release -o /out --no-restore

# Use official runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy compiled output from build stage
COPY --from=build /out ./

# Expose the port your app will run on
EXPOSE 9090

# Start the app
ENTRYPOINT ["dotnet", "MySecondApiProject.dll"]
