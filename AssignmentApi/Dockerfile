# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["AssignmentApi/AssignmentApi.csproj", "AssignmentApi/"]
RUN dotnet restore "AssignmentApi/AssignmentApi.csproj"

COPY . .
WORKDIR /src/AssignmentApi
RUN dotnet publish "AssignmentApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "AssignmentApi.dll"]