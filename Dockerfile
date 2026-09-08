# ---------- build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# copy project files
COPY ZealandPortfolioWeb/ZealandPortfolioWeb.csproj ZealandPortfolioWeb/
COPY ZealandPortfolioLib/ZealandPortfolioLib.csproj ZealandPortfolioLib/

# restore the Razor Pages project
RUN dotnet restore ZealandPortfolioWeb/ZealandPortfolioWeb.csproj

# copy source code
COPY . .

# publish the Razor Pages application
RUN dotnet publish ZealandPortfolioWeb/ZealandPortfolioWeb.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

# ---------- runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

# copy published output
COPY --from=build /app/publish .

# expose port (ASP.NET default inside container)
EXPOSE 8080

# set environment
ENV ASPNETCORE_URLS=http://+:8080

# run the app
ENTRYPOINT ["dotnet", "ZealandPortfolioWeb.dll"]
