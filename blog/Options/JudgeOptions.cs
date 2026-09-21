using System.ComponentModel.DataAnnotations;

namespace blog.Options
{
    /// <summary>
    /// 判題沙盒設定。可用環境變數覆蓋：JudgeOptions__DockerEndpoint、JudgeOptions__SandBoxPath ...
    /// </summary>
    public sealed class JudgeOptions
    {
        /// <summary>
        /// Docker engine 位置。Windows 預設 named pipe，Linux 預設 unix socket。
        /// </summary>
        [Required]
        public string DockerEndpoint { get; set; } =
            OperatingSystem.IsWindows()
                ? "npipe://./pipe/docker_engine"
                : "unix:///var/run/docker.sock";

        /// <summary>
        /// 暫存程式碼的目錄，會 bind mount 進沙盒容器。
        /// 容器化部署時 host 與 API container 內路徑必須一致（compose 掛 /tmp/judgeTemp:/tmp/judgeTemp）。
        /// </summary>
        [Required]
        public string SandBoxPath { get; set; } =
            OperatingSystem.IsWindows() ? @"C:\PushAPI\judgeTemp" : "/tmp/judgeTemp";

        [Range(1, 300)]
        public int TimeoutSeconds { get; set; } = 15;

        [Range(16 * 1024 * 1024, 4L * 1024 * 1024 * 1024)]
        public long MemoryLimitBytes { get; set; } = 128 * 1024 * 1024;
    }
}
