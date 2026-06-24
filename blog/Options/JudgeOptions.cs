namespace blog.Options
{
    public sealed class JudgeOptions
    {
        public int TimeoutMs { get; init; } = 2000;
        public long MemoryLimitBytes { get; init; } = 128 * 1024 * 1024;
        public string SandBoxPath { get; init; }
    }
}
