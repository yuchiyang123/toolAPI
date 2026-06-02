# Stage 1: build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["blog/blog.csproj", "blog/"]
RUN dotnet restore "blog/blog.csproj"
COPY . .
WORKDIR "/src/blog"
RUN dotnet publish "blog.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "blog.dll"]