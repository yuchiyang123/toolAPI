# judge-csharp Docker image

`JudgeConfig.cs` 執行 C# 判題時用的沙盒環境（`LocalImages` 裡的 `judge-csharp:latest`）。
以前是在原本那台 Windows 機器的 Docker Desktop 上手動建的，Dockerfile 從沒進過 repo；
現在改成完全可重建，靠這兩個檔案 (`Dockerfile` + `template.csproj`) 就能重現。

## 建置與部署

Judge 沙盒用的是一顆跟 host 隔離的 Docker-in-Docker（`judge-dind`，見
`docker-compose.judge.example.yml`），沒有對外開 port，所以不能直接
`docker build` 進去——流程是「在 host 的主 daemon 建好 image → 用
`docker save`/`docker load` 匯進 judge-dind」：

```bash
# 1. 在 VM 上，用 host 的主 daemon 建 image（有網路，能拉 base image / 還原套件）
cd ~/projects/toolAPI
docker build -t judge-csharp:latest judge-sandbox/csharp/

# 2. 匯進隔離的 judge-dind（不需要對外開 port，直接透過 docker exec 的 stdin 灌進去）
docker save judge-csharp:latest | docker exec -i toolapi-judge-dind-1 docker load
```

`judge-dind` 重建（例如換了新的 volume）之後，第 2 步要重做一次，因為它的
image 儲存空間是獨立的（`judge-dind-storage` volume），不會跟 host 共用。

## 驗證

```bash
curl -X POST https://api.matthewyu.uk/toolAPI/api/Judge \
  -H "Content-Type: application/json" \
  -d '{"language":"csharp","code":"Console.WriteLine(1+1);"}'
# 預期： {"stdout":"2\n","stderr":""}
```
