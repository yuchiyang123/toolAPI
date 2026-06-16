namespace blog.Entities.Judge
{
    public class Problem
    {
        public int Id { get; set; }
        public required string ProblemName { get; set; }
        public required string Description { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<Function> Functions { get; set; }
        public ICollection<Submission> Submissions { get; set; }
    }
}
