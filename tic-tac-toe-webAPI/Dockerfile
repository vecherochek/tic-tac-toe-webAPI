FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["tic-tac-toe-webAPI/tic-tac-toe-webAPI.csproj", "tic-tac-toe-webAPI/"]
RUN dotnet restore "tic-tac-toe-webAPI/tic-tac-toe-webAPI.csproj"
COPY . .
WORKDIR "/src/tic-tac-toe-webAPI"
RUN dotnet build "tic-tac-toe-webAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tic-tac-toe-webAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tic-tac-toe-webAPI.dll"]
