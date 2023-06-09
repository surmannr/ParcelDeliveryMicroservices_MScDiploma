#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservices/Employees/Employees.API/Employees.API.csproj", "Microservices/Employees/Employees.API/"]
COPY ["Microservices/_Common/Common/Common.csproj", "Microservices/_Common/Common/"]
RUN dotnet restore "Microservices/Employees/Employees.API/Employees.API.csproj"
COPY . .
WORKDIR "/src/Microservices/Employees/Employees.API"
RUN dotnet build "Employees.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Employees.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Employees.API.dll"]