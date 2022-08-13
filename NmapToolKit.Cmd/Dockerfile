#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app
RUN apt-get update && apt-get upgrade -y
RUN apt-get install -y \
		nmap \
		net-tools \
		iproute2 

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NmapToolKit.Cmd/NmapToolKit.Cmd.csproj", "NmapToolKit.Cmd/"]
RUN dotnet restore "NmapToolKit.Cmd/NmapToolKit.Cmd.csproj"
COPY . .
WORKDIR "/src/NmapToolKit.Cmd"
RUN dotnet build "NmapToolKit.Cmd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NmapToolKit.Cmd.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NmapToolKit.Cmd.dll"]