#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

RUN curl -sL https://deb.nodesource.com/setup_14.x |  bash -
RUN apt-get install -y nodejs


WORKDIR /src
COPY ["ShareMyPaper.Web/ShareMyPaper.Web.csproj", "ShareMyPaper.Web/"]
COPY ["ShareMyPaper.Domain/ShareMyPaper.Domain.csproj", "ShareMyPaper.Domain/"]
COPY ["ShareMyPaper.Application/ShareMyPaper.Application.csproj", "ShareMyPaper.Application/"]
COPY ["ShareMyPaper.Infraestructure/ShareMyPaper.Infraestructure.csproj", "ShareMyPaper.Infraestructure/"]
RUN dotnet restore "ShareMyPaper.Web/ShareMyPaper.Web.csproj"
COPY . .
WORKDIR "/src/ShareMyPaper.Web"
RUN dotnet build "ShareMyPaper.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShareMyPaper.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShareMyPaper.Web.dll"]