namespace blog.Entities.Judge
{
    public class ProblemParameters
    {
        public int Id { get; set; }
        public int SignatureId { get; set; }
        public required string ParameterName { get; set; }
        public required string Type { get; set; }
        public ProblemSignature ProblemSignature { get; set; }
    }
}
