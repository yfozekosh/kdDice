FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
RUN echo $(ls -a)
COPY ../../ .
RUN echo $(ls -a)

WORKDIR /src/KdDice.Processing
RUN rm -rf bin
RUN rm -rf obj
RUN echo $(ls -a)
RUN dotnet restore "KdDice.Processing.csproj"
RUN dotnet build "KdDice.Processing.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "KdDice.Processing.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KdDice.Processing.dll"]