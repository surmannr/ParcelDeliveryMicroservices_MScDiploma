#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservices/PackageDelivery/PackageDelivery.API/PackageDelivery.API.csproj", "Microservices/PackageDelivery/PackageDelivery.API/"]
COPY ["BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "BuildingBlocks/EventBus.Messages/"]
COPY ["Microservices/PackageDelivery/PackageDelivery.BL/PackageDelivery.BL.csproj", "Microservices/PackageDelivery/PackageDelivery.BL/"]
COPY ["Microservices/PackageDelivery/PackageDelivery.DAL/PackageDelivery.DAL.csproj", "Microservices/PackageDelivery/PackageDelivery.DAL/"]
COPY ["Microservices/_Common/Common/Common.csproj", "Microservices/_Common/Common/"]
RUN dotnet restore "Microservices/PackageDelivery/PackageDelivery.API/PackageDelivery.API.csproj"
COPY . .
WORKDIR "/src/Microservices/PackageDelivery/PackageDelivery.API"
RUN dotnet build "PackageDelivery.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PackageDelivery.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PackageDelivery.API.dll"]