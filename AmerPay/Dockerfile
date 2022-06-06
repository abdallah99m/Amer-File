#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AmerPay/AmerPay.csproj", "AmerPay/"]
COPY ["AmerPay.DataAccess/AmerPay.DataAccess.csproj", "AmerPay.DataAccess/"]
COPY ["AmerPay.Models/AmerPay.Models.csproj", "AmerPay.Models/"]
RUN dotnet restore "AmerPay/AmerPay.csproj"
COPY . .
WORKDIR "/src/AmerPay"
RUN dotnet build "AmerPay.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AmerPay.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AmerPay.dll"]