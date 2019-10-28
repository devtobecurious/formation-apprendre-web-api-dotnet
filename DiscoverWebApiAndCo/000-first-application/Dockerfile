#https://docs.microsoft.com/fr-fr/learn/modules/intro-to-containers/5-exercise-create-custom-docker-image

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS tobebuild
WORKDIR /src
COPY ["000-first-application/000-first-application.csproj", "000-first-application/"]
RUN dotnet restore "000-first-application/000-first-application.csproj"
COPY . .
WORKDIR "/src/000-first-application"
RUN dotnet build "000-first-application.csproj" -c Release -o /applications/build

FROM tobebuild AS tobepublish
RUN dotnet publish "000-first-application.csproj" -c Release -o /applications/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS basetolaunch
WORKDIR /applications
EXPOSE 80
EXPOSE 443

FROM basetolaunch AS final
WORKDIR /applications
COPY --from=tobepublish /applications/publish .
ENTRYPOINT ["dotnet", "000-first-application.dll"]