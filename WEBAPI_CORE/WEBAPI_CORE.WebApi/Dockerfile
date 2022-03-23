#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["WEBAPI_CORE/WEBAPI_CORE.WebApi/WEBAPI_CORE.WebApi.csproj", "WEBAPI_CORE/WEBAPI_CORE.WebApi/"]
COPY ["WEBAPI_CORE/WEBAPI_CORE.Infrastructure.Persistence/WEBAPI_CORE.Infrastructure.Persistence.csproj", "WEBAPI_CORE/WEBAPI_CORE.Infrastructure.Persistence/"]
COPY ["WEBAPI_CORE/WEBAPI_CORE.Application/WEBAPI_CORE.Application.csproj", "WEBAPI_CORE/WEBAPI_CORE.Application/"]
COPY ["WEBAPI_CORE/WEBAPI_CORE.Domain/WEBAPI_CORE.Domain.csproj", "WEBAPI_CORE/WEBAPI_CORE.Domain/"]
COPY ["WEBAPI_CORE/WEBAPI_CORE.Infrastructure.Identity/WEBAPI_CORE.Infrastructure.Identity.csproj", "WEBAPI_CORE/WEBAPI_CORE.Infrastructure.Identity/"]
COPY ["WEBAPI_CORE/WEBAPI_CORE.Infrastructure.Shared/WEBAPI_CORE.Infrastructure.Shared.csproj", "WEBAPI_CORE/WEBAPI_CORE.Infrastructure.Shared/"]
RUN dotnet restore "WEBAPI_CORE/WEBAPI_CORE.WebApi/WEBAPI_CORE.WebApi.csproj"
COPY . .
WORKDIR "/src/WEBAPI_CORE/WEBAPI_CORE.WebApi"
RUN dotnet build "WEBAPI_CORE.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WEBAPI_CORE.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WEBAPI_CORE.WebApi.dll"]