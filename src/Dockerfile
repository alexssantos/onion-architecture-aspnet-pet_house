#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#See Logs details: $docker build --progress=plain --no-cache -t pethouse-img .

# 1 - copy csproj and restore as distinct layers
# 2 - copy and publish app and libraries
# 3 - final stage/image

# ------------------ Example ------------------
# #1 copy csproj and restore as distinct layers
# COPY aspnetapp/*.csproj .
# RUN dotnet restore -a $TARGETARCH

# #2 copy and publish app and libraries
# COPY aspnetapp/. .
# RUN dotnet publish -a $TARGETARCH --no-restore -o /app


# #3 final stage/image
# FROM mcr.microsoft.com/dotnet/aspnet:8.0
# WORKDIR /app
# COPY --from=build /app .
# USER $APP_UID
# ENTRYPOINT ["./aspnetapp"]
# --------------------------------------------

# env1 SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

ENV PROJECT="PetHouse.Api/PetHouse.Api.csproj"
WORKDIR /build
# copia tudo DA pasta raiz (dockerfile) e abaixo PARA pasta atual do meu ambiente (build-env).
COPY . .
RUN dotnet restore $PROJECT
RUN dotnet build $PROJECT -c Release -o /app/build


FROM build-env AS publish-env
# usando o ambiente "publish-env", publica o proj emuma pasta.
###Implicit restore in cmd "$dotnet publish".
RUN dotnet publish $PROJECT -c Release -o /app/published 

RUN dir -s 

# LOCAL1
# env1
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime-env
EXPOSE 80
EXPOSE 443
WORKDIR /app
COPY --from=publish-env /app/published .
ENV DLL_NAME="PetHouse.Api.dll"
ENTRYPOINT ["dotnet", $DLL_NAME]