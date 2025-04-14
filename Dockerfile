# Use the official .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory
WORKDIR /app

# Copy the server project files
COPY HalfChessServer/ ./HalfChessServer/

# Build the server application
WORKDIR /app/HalfChessServer
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Use the ASP.NET runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the published server application
COPY --from=build /app/HalfChessServer/out ./

# Copy the database DACPAC file
COPY 3.database/HalfChessDB.dacpac ./database/

# Expose port for the server
EXPOSE 80
EXPOSE 443

# Environment variables for database connection (override these when running the container)
ENV ConnectionStrings__DefaultConnection="Server=host.docker.internal,1433;Database=HalfChessDB;User Id=sa;Password=YourPassword;"

# Run the server application
ENTRYPOINT ["dotnet", "HalfChessServer.dll"]