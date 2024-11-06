FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/ThueDat.Web.Host/ThueDat.Web.Host.csproj", "src/ThueDat.Web.Host/"]
COPY ["src/ThueDat.Web.Core/ThueDat.Web.Core.csproj", "src/ThueDat.Web.Core/"]
COPY ["src/ThueDat.Application/ThueDat.Application.csproj", "src/ThueDat.Application/"]
COPY ["src/ThueDat.Core/ThueDat.Core.csproj", "src/ThueDat.Core/"]
COPY ["src/ThueDat.EntityFrameworkCore/ThueDat.EntityFrameworkCore.csproj", "src/ThueDat.EntityFrameworkCore/"]
WORKDIR "/src/src/ThueDat.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/ThueDat.Web.Host", "src/ThueDat.Web.Host"]
COPY ["src/ThueDat.Web.Core", "src/ThueDat.Web.Core"]
COPY ["src/ThueDat.Application", "src/ThueDat.Application"]
COPY ["src/ThueDat.Core", "src/ThueDat.Core"]
COPY ["src/ThueDat.EntityFrameworkCore", "src/ThueDat.EntityFrameworkCore"]
WORKDIR "/src/src/ThueDat.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "ThueDat.Web.Host.dll"]
