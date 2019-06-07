FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SItkoCRM/SItkoCRM.csproj", "SItkoCRM/"]
RUN dotnet restore "SItkoCRM/SItkoCRM.csproj"
COPY . .
WORKDIR "/src/SItkoCRM"
RUN dotnet build "SItkoCRM.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SItkoCRM.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SItkoCRM.dll"]