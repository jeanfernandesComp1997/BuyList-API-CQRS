FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BuyList.Api/BuyList.Api.csproj", "BuyList.Api/"]
COPY ["BuyList.Infra/BuyList.Infra.csproj", "BuyList.Infra/"]
COPY ["BuyList.Domain/BuyList.Domain.csproj", "BuyList.Domain/"]
RUN dotnet restore "BuyList.Api/BuyList.Api.csproj"
COPY . .
WORKDIR "/src/BuyList.Api"
RUN dotnet build "BuyList.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BuyList.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BuyList.Api.dll"]