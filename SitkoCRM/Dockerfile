FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SItkoCRM/SitkoCRM.csproj", "SItkoCRM/"]
RUN dotnet restore "SItkoCRM/SitkoCRM.csproj"
COPY . .
WORKDIR "/src/SItkoCRM"
RUN dotnet build "SitkoCRM.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SitkoCRM.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SitkoCRM.dll"]
