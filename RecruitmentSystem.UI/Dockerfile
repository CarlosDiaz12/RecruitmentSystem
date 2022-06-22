#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RecruitmentSystem.UI/RecruitmentSystem.UI.csproj", "RecruitmentSystem.UI/"]
COPY ["RecruitmentSystem.Domain/RecruitmentSystem.Domain.csproj", "RecruitmentSystem.Domain/"]
COPY ["RecruitmentSystem.Infrastructure/RecruitmentSystem.Infrastructure.csproj", "RecruitmentSystem.Infrastructure/"]
RUN dotnet restore "RecruitmentSystem.UI/RecruitmentSystem.UI.csproj"
COPY . .
WORKDIR "/src/RecruitmentSystem.UI"
RUN dotnet build "RecruitmentSystem.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecruitmentSystem.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecruitmentSystem.UI.dll"]