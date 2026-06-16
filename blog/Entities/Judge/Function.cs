using blog.Common.Enum;

namespace blog.Entities.Judge
{
    public class Function
    {
        public int Id { get; set; }
        public int ProblemId { get; set; }
        public JudgeLanguageEnum Language { get; set; }
        public required string Input { get; set; }
        public required string Expected { get; set; }
        public Problem Problem { get; set; }
    }
}
