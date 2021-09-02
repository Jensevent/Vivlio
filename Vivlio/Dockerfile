# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY Vivlio/*.sln .
COPY Vivlio/*.csproj ./Vivlio/
RUN dotnet restore Vivlio
RUN dotnet restore ./Vivlio
RUN dotnet restore "Vivlio"

# copy everything else and build app
COPY . .
WORKDIR /source/Vivlio
RUN dotnet publish -c release -o /app 

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Vivlio.dll"]