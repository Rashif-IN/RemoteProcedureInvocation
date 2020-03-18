FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY user_handler/user_handler.csproj user_handler/
RUN dotnet restore "user_handler/user_handler.csproj"
COPY . .
WORKDIR "/src/user_handler"
RUN dotnet build "user_handler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "user_handler.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "user_handler.dll"]
