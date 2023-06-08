FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

EXPOSE 5200

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["majumi.MechanicApp.BlazorServer/majumi.MechanicApp.BlazorServer.csproj", "majumi.MechanicApp.BlazorServer/"]
COPY ["majumi.MechanicApp.Controller/majumi.MechanicApp.Controller.csproj", "majumi.MechanicApp.Controller/"]
COPY ["majumi.MechanicApp.Utilities/majumi.MechanicApp.Utilities.csproj", "majumi.MechanicApp.Utilities/"]
COPY ["majumi.MechanicApp.Model/majumi.MechanicApp.Model.csproj", "majumi.MechanicApp.Model/"]
COPY ["majumi.MechanicApp.Tests/majumi.MechanicApp.Tests.csproj", "majumi.MechanicApp.Tests/"]
RUN dotnet restore "majumi.MechanicApp.BlazorServer/majumi.MechanicApp.BlazorServer.csproj"
COPY . .
WORKDIR "/src/majumi.MechanicApp.BlazorServer"
RUN dotnet build "majumi.MechanicApp.BlazorServer.csproj" -c Production -o /app/build

FROM build AS publish
RUN dotnet publish "majumi.MechanicApp.BlazorServer.csproj" -c Production -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "majumi.MechanicApp.BlazorServer.dll"]