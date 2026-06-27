namespace blog.Options
{
    public sealed class JudgeOptions
    {
        public int TimeoutMs { get; init; } = 15;
        public long MemoryLimitBytes { get; init; } = 128 * 1024 * 1024;
        public required string SandBoxPath { get; init; }
    }
}
