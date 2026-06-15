namespace blog.Dtos.Judge
{
    public class JudgeDto
    {
        public required string Language { get; set; }
        public required string Code { get; set; }
    }

    public class JudgeResult
    {
        public string? Stdout { get; set; }
        public string? Stderr { get; set; }
    }
}
