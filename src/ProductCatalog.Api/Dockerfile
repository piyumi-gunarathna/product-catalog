FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProductCatalog.Api/ProductCatalog.Api.csproj", "ProductCatalog.Api/"]
COPY ["ProductCatalog.Domain/ProductCatalog.Domain.csproj", "ProductCatalog.Domain/"]
COPY ["ProductCatalog.Infrastructure/ProductCatalog.Infrastructure.csproj", "ProductCatalog.Infrastructure/"]
RUN dotnet restore "ProductCatalog.Api/ProductCatalog.Api.csproj"
COPY . .
WORKDIR "/src/ProductCatalog.Api"
RUN dotnet build "ProductCatalog.Api.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "ProductCatalog.Api.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductCatalog.Api.dll"]
