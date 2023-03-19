#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservices/PackageTracking/PackageTracking.API/PackageTracking.API.csproj", "Microservices/PackageTracking/PackageTracking.API/"]
COPY ["Microservices/PackageTracking/PackageTracking.DAL/PackageTracking.DAL.csproj", "Microservices/PackageTracking/PackageTracking.DAL/"]
RUN dotnet restore "Microservices/PackageTracking/PackageTracking.API/PackageTracking.API.csproj"
COPY . .
WORKDIR "/src/Microservices/PackageTracking/PackageTracking.API"
RUN dotnet build "PackageTracking.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PackageTracking.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PackageTracking.API.dll"]