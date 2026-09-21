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

# 正式環境（docker compose）需要：
#   environment:
#     - File__BasePath=/app/files
#     - JudgeOptions__DockerEndpoint=unix:///var/run/docker.sock
#     - JudgeOptions__SandBoxPath=/tmp/judgeTemp
#   volumes:
#     - ./files:/app/files
#     - /var/run/docker.sock:/var/run/docker.sock   # 判題沙盒要能建容器
#     - /tmp/judgeTemp:/tmp/judgeTemp               # host 與 API container 路徑必須一致，沙盒容器 bind mount 用
RUN mkdir -p /app/files /tmp/judgeTemp

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "blog.dll"]
