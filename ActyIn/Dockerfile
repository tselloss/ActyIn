#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
WORKDIR /src
COPY ["ActyIn/ActyIn.csproj", "ActyIn/"]
COPY ["Athletes.Info/Athletes.Info.csproj", "Athletes.Info/"]
COPY ["Define.Common/Define.Common.csproj", "Define.Common/"]
COPY ["Postgres.Context/Postgres.Context.csproj", "Postgres.Context/"]
COPY ["BookingModel.Info/BookingModel.Info.csproj", "BookingModel.Info/"]
COPY ["MatchActivity.Info/MatchActivity.Info.csproj", "MatchActivity.Info/"]
COPY ["ChooseActivity.Info/ChooseActivity.Info.csproj", "ChooseActivity.Info/"]
COPY ["HealthCheck/HealthCheck.csproj", "HealthCheck/"]
COPY ["PhotoProfile.Info/PhotoProfile.Info.csproj", "PhotoProfile.Info/"]
COPY ["User.Authorization/User.Authorization.csproj", "User.Authorization/"]
RUN dotnet restore "ActyIn/ActyIn.csproj"
COPY . .
WORKDIR "/src/ActyIn"
RUN dotnet build "ActyIn.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ActyIn.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ActyIn.dll"]