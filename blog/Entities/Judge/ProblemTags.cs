namespace blog.Entities.Judge
{
    public class ProblemTags
    {
        public int Id { get; set; }
        public int ProblemId { get; set; }
        public required string Name { get; set; }
        public Problem Problem { get; set; }
    }
}
