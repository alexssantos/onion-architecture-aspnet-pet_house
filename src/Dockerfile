#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#See Logs details: $docker build --progress=plain --no-cache -t pethouse-img .
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443

#original ajustado com path
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PetHouse.Api/PetHouse.Api.csproj", "PetHouse.Api/"]
RUN dotnet restore "PetHouse.Api/PetHouse.Api.csproj"
COPY . .

WORKDIR "/src/PetHouse.Api"
RUN dotnet build "PetHouse.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetHouse.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetHouse.Api.dll"]