#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UsersMicroServiceAPI/UsersMicroServiceAPI.csproj", "UsersMicroServiceAPI/"]
COPY ["UsersKeyServices/UsersKeyServices.csproj", "UsersKeyServices/"]
COPY ["UsersModels/UsersModels.csproj", "UsersModels/"]
COPY ["UsersServices/UsersServices.csproj", "UsersServices/"]
COPY ["SharedProject/SharedProject.csproj", "SharedProject/"]
RUN dotnet restore "UsersMicroServiceAPI/UsersMicroServiceAPI.csproj"
COPY . .
WORKDIR "/src/UsersMicroServiceAPI"
RUN dotnet build "UsersMicroServiceAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UsersMicroServiceAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UsersMicroServiceAPI.dll"]