#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
RUN apt update
RUN apt install -y nodejs npm
WORKDIR /src
COPY ["LarsV2.csproj", "LarsV2.App/"]
RUN dotnet restore "LarsV2.App/LarsV2.csproj"
WORKDIR "/src/LarsV2.App"
COPY . .
RUN dotnet build "LarsV2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LarsV2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LarsV2.dll"]