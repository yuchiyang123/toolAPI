using System.Text.Json.Serialization;
using blog.Common.Enum;
using blog.Dtos.Page;

namespace blog.Dtos.Judge
{
    public class JudgeDto
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public required JudgeLanguageEnum Language { get; set; }
        public required string Code { get; set; }
    }

    public class JudgeResult
    {
        public string? Stdout { get; set; }
        public string? Stderr { get; set; }
    }

    public class JudgeRequestDto : JudgeDto
    {
        public int Id { get; set; }
    }

    public abstract class BaseProblem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required ProblemDifficultyEnums Difficulty { get; set; }
        public int PassCount { get; set; }
        public int TotalCount { get; set; }
        public double PassRate => TotalCount == 0 ? 0 : (double)PassCount / TotalCount;
        public List<string>? Tags { get; set; }
    }

    public class ProblemsListQuery : PageQueryDto { }

    public class ProblemsList : BaseProblem { }

    public class ProblemDetail : BaseProblem
    {
        public required string Description { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }
        public List<SubmissionDto> Submissions { get; set; }
        public List<TestCases>? TestCases { get; set; }
    }

    public class SubmissionDto
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public SubmissionStatus Status { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public UserDto User { get; set; }
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        public int Id { get; set; }
        public required string Output { get; set; }
        public bool IsPassed { get; set; }
    }

    public class JudgeResultReponse : Result { }

    public class TestCases
    {
        public required string Input { get; set; }
        public required string Output { get; set; }
    }

    public class TestCode
    {
        public int Id { get; set; }
        public required string Input { get; set; }
    }
}
