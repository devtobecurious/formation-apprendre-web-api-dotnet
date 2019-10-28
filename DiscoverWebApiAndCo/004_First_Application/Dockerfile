FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["004_First_Application/004_First_Application.csproj", "004_First_Application/"]
RUN dotnet restore "004_First_Application/004_First_Application.csproj"
COPY . .
WORKDIR "/src/004_First_Application"
RUN dotnet build "004_First_Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "004_First_Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "004_First_Application.dll"]