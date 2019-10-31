FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["0041_First_Application/0041_First_Application.csproj", "0041_First_Application/"]
RUN dotnet restore "0041_First_Application/0041_First_Application.csproj"
COPY . .
WORKDIR "/src/0041_First_Application"
RUN dotnet build "0041_First_Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "0041_First_Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "0041_First_Application.dll"]