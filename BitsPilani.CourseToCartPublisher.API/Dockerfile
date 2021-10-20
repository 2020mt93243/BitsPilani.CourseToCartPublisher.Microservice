#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["BitsPilani.CourseToCartPublisher.API/BitsPilani.CourseToCartPublisher.API.csproj", "BitsPilani.CourseToCartPublisher.API/"]
RUN dotnet restore "BitsPilani.CourseToCartPublisher.API/BitsPilani.CourseToCartPublisher.API.csproj"
COPY . .
WORKDIR "/src/BitsPilani.CourseToCartPublisher.API"
RUN dotnet build "BitsPilani.CourseToCartPublisher.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BitsPilani.CourseToCartPublisher.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BitsPilani.CourseToCartPublisher.API.dll"]