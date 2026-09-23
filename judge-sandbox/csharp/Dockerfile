# 判題沙盒用的 C# 執行環境（JudgeConfig.cs 裡 judge-csharp:latest 這個 image）。
#
# JudgeService 執行時把這個 image 跑在 NetworkMode=none 的容器裡，所以套件還原
# 一定要離線成功。做法：build 階段（有網路）先用 template.csproj 跑一次
# restore，把套件暖進 image 自帶的 NuGet 全域快取（/root/.nuget/packages）；
# 執行期（無網路）用同一個快取路徑當 local feed 離線還原 ——
# 對照 JudgeConfig.cs 的 cmd：
#   cp /template/template.csproj /code/ && cp /code/main.cs /code/Program.cs
#   && rm /code/main.cs && cd /code
#   && dotnet restore --source /root/.nuget/packages -v q
#   && dotnet run --no-restore -v q
#
# template.csproj 目前沒有任何 PackageReference，純粹是一個 net9.0 主控台專案，
# 跟 blog.csproj 用同一個 TargetFramework。之後真的需要額外套件（例如題目要用
# System.Numerics.BigInteger 之外的東西）就加進 template.csproj，重新 build 這個
# image 即可，套件會一起被暖進快取。
FROM mcr.microsoft.com/dotnet/sdk:9.0

WORKDIR /template
COPY template.csproj .

RUN mkdir -p /tmp/seed \
    && cp template.csproj /tmp/seed/ \
    && printf 'System.Console.WriteLine();\n' > /tmp/seed/Program.cs \
    && cd /tmp/seed \
    && dotnet restore --source /root/.nuget/packages -v q \
    && cd / && rm -rf /tmp/seed

WORKDIR /code
