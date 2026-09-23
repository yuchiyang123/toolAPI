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

# 這一步在 build 階段以 root 執行，此時 HOME 還是預設的 /root ——
# 刻意不要提前設 HOME=/tmp，不然 dotnet/NuGet 在這裡建立的 scratch 目錄
# 會被 root 擁有並「烤」進 image 的 /tmp 底下，之後沙盒容器用 1000:1000
# 執行時就會因為那些目錄已經存在且不可寫而炸掉（實際踩過這個坑）。
RUN mkdir -p /tmp/seed \
    && cp template.csproj /tmp/seed/ \
    && printf 'System.Console.WriteLine();\n' > /tmp/seed/Program.cs \
    && cd /tmp/seed \
    && dotnet restore --source /root/.nuget/packages -v q \
    && cd / && rm -rf /tmp/seed

# 沙盒容器用不存在於 /etc/passwd 的 uid 1000:1000 跑（沒有 HOME、沒有寫入
# 任何系統目錄的權限）。dotnet CLI 預設第一次執行會想寫 first-time-use
# sentinel、NuGet 設定/快取到 $HOME，uid 沒有對應帳號時 $HOME 解析不到或
# 指到不可寫的地方，會直接炸掉。這幾個是官方建議在 container/CI 跑 dotnet
# CLI 的標準做法；HOME 指到 /tmp 是因為 /tmp 本身是 1777（任何人可寫），
# 讓 1000:1000 在裡面自己建立全新的 .nuget/.dotnet 之類的 scratch 目錄。
ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true
ENV DOTNET_NOLOGO=true
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true
# 執行環境每次都是全新 ephemeral 容器，workload 完整性檢查（比對 manifest
# 快取）在這種一次性環境下沒有意義，只會多印一行「An issue was encountered
# verifying workloads」污染 stdout（判題結果直接回給前端，這行雜訊會混進去）。
ENV DOTNET_SKIP_WORKLOAD_INTEGRITY_CHECK=true
ENV HOME=/tmp

WORKDIR /code
