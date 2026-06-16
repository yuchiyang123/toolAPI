using blog.Common.Enum;
using blog.Entities.User;

namespace blog.Entities.Judge
{
    public class Submission
    {
        public int Id { get; set; }
        public int ProblemId { get; set; }
        public JudgeLanguageEnum Language { get; set; }
        public required string Code { get; set; }
        public SubmissionStatus Status { get; set; }
        public int PassedCount { get; set; }
        public int TotalCount { get; set; }
        public DateTime SubmittedAt { get; set; }
        public int UserId { get; set; }
        public Users Users { get; set; }
        public Problem Problem { get; set; }
        public ICollection<SubmissionResult> SubmissionResults { get; set; }
    }
}
