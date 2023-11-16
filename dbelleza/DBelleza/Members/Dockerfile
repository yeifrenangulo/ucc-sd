FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY ./dbelleza/DBelleza/Members/Members.csproj .
RUN dotnet restore

COPY ./dbelleza/DBelleza/Members/ .
RUN dotnet build -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Members.dll"]