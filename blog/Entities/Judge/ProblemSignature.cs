using blog.Common.Enum;

namespace blog.Entities.Judge
{
    public class ProblemSignature
    {
        public int Id { get; set; }
        public int ProblemId { get; set; }
        public JudgeLanguageEnum Language { get; set; }
        public required string FunctionName { get; set; }
        public Problem Problem { get; set; }
    }
}
