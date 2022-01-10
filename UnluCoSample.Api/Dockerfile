#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UnluCoSample.Api/UnluCoSample.Api.csproj", "UnluCoSample.Api/"]
COPY ["UnluCoSample.Infrastructure/UnluCoSample.Infrastructure.csproj", "UnluCoSample.Infrastructure/"]
COPY ["UnluCoSample.Domain/UnluCoSample.Domain.csproj", "UnluCoSample.Domain/"]
COPY ["UnluCoSample.Application/UnluCoSample.Application.csproj", "UnluCoSample.Application/"]
RUN dotnet restore "UnluCoSample.Api/UnluCoSample.Api.csproj"
COPY . .
WORKDIR "/src/UnluCoSample.Api"
RUN dotnet build "UnluCoSample.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnluCoSample.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UnluCoSample.Api.dll"]