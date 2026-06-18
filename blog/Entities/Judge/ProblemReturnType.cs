namespace blog.Entities.Judge
{
    public class ProblemReturnType
    {
        public int Id { get; set; }
        public int SignatureId { get; set; }
        public required string ReturnName { get; set; }
        public required string ReturnType { get; set; }
        public ProblemSignature ProblemSignature { get; set; }
    }
}
