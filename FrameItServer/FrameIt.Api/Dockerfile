# שלב בסיס להרצה
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# שלב בנייה
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# העתקת קבצי csproj
COPY ["FrameIt.Api/FrameIt.Api.csproj", "FrameIt.Api/"]
COPY ["FrameIt.Service/FrameIt.Service.csproj", "FrameIt.Service/"]
COPY ["FrameIt.Core/FrameIt.Core.csproj", "FrameIt.Core/"]
COPY ["FrameIt.Data/FrameIt.Data.csproj", "FrameIt.Data/"]

# שחזור תלויות
RUN dotnet restore "FrameIt.Api/FrameIt.Api.csproj"

# העתקת שאר הקוד
COPY . .

WORKDIR "/src/FrameIt.Api"
RUN dotnet build "FrameIt.Api.csproj" -c Release -o /app/build

# שלב פרסום
FROM build AS publish
RUN dotnet publish "FrameIt.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# שלב סופי – הרצה
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FrameIt.Api.dll"]
