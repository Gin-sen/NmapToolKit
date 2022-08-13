#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN apt-get update && apt-get upgrade
RUN apt-get install -y nmap

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NmapToolKit/NmapToolKit.csproj", "NmapToolKit/"]
RUN dotnet restore "NmapToolKit/NmapToolKit.csproj"
COPY . .
WORKDIR "/src/NmapToolKit"
RUN dotnet build "NmapToolKit.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NmapToolKit.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NmapToolKit.dll"]