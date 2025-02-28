#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["dotnety.Api/dotnety.Api.csproj", "dotnety.Api/"]
COPY ["dotnety.Infrastructure/dotnety.Infrastructure.csproj", "dotnety.Infrastructure/"]
COPY ["dotnety.Domain/dotnety.Domain.csproj", "dotnety.Domain/"]
COPY ["dotnety.Application/dotnety.Application.csproj", "dotnety.Application/"]
RUN dotnet restore "dotnety.Api/dotnety.Api.csproj"
COPY . .
WORKDIR "/src/dotnety.Api"
RUN dotnet build "dotnety.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotnety.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotnety.Api.dll"]