namespace blog.Entities.Judge
{
    public class SubmissionResult
    {
        public int Id { get; set; }
        public int FunctionId { get; set; }
        public int SubmissionId { get; set; }
        public required string ActualOutput { get; set; }
        public bool IsPassed { get; set; }
        public Submission Submission { get; set; }
    }
}
