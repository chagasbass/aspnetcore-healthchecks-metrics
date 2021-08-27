FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY *.sln .

COPY ./AspnetCore.Healthchecks/*  ./AspnetCore.Healthchecks/
COPY ./AspnetCore.Healthchecks.Data/* ./AspnetCore.Healthchecks.Data/
COPY ./AspnetCore.Healthchecks.Domain/* ./AspnetCore.Healthchecks.Domain/
 
RUN dotnet restore AspnetCore.Healthchecks/AspnetCore.Healthchecks.csproj

RUN dotnet publish AspnetCore.Healthchecks/AspnetCore.Healthchecks.csproj --no-restore --nologo -v m -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
 
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AspnetCore.Healthchecks.dll"]