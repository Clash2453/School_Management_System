FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["School Management System/School Management System.csproj", "School Management System/"]
RUN dotnet restore "School Management System/School Management System.csproj"
COPY . .
WORKDIR "/src/School Management System"
RUN dotnet build "School Management System.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "School Management System.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "School Management System.dll"]
