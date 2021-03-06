FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY *.sln .

COPY ./AspnetCore.Healthchecks.Metrics/*  ./AspnetCore.Healthchecks.Metrics/
COPY ./AspnetCore.Healthchecks.Metrics.Data/* ./AspnetCore.Healthchecks.Metrics.Data/
COPY ./AspnetCore.Healthchecks.Metrics.Domain/* ./AspnetCore.Healthchecks.Metrics.Domain/
COPY ./AspnetCore.Healthchecks.Metrics.ApplicationServices/* ./AspnetCore.Healthchecks.Metrics.ApplicationServices/
 
RUN dotnet restore AspnetCore.Healthchecks.Metrics/AspnetCore.Healthchecks.Metrics.Api.csproj

RUN dotnet publish AspnetCore.Healthchecks/AspnetCore.Healthchecks.Metrics.Api.csproj --no-restore --nologo -v m -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
 
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AspnetCore.Healthchecks.Metrics.Api.dll"]