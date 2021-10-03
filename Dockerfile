#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Api.ConfTerm.Presentation/Api.ConfTerm.Presentation.csproj", "src/Api.ConfTerm.Presentation/"]
COPY ["src/Api.ConfTerm.Application/Api.ConfTerm.Application.csproj", "src/Api.ConfTerm.Application/"]
COPY ["src/Api.ConfTerm.Domain/Api.ConfTerm.Domain.csproj", "src/Api.ConfTerm.Domain/"]
COPY ["src/Api.ConfTerm.Data/Api.ConfTerm.Data.csproj", "src/Api.ConfTerm.Data/"]
RUN dotnet restore "src/Api.ConfTerm.Presentation/Api.ConfTerm.Presentation.csproj"
COPY . .
WORKDIR "/src/src/Api.ConfTerm.Presentation"
RUN dotnet build "Api.ConfTerm.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.ConfTerm.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Api.ConfTerm.Presentation.dll