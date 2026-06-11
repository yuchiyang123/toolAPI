namespace blog.Entities._8bit
{
    public class Step
    {
        public int Id { get; set; }
        public int TrackId { get; set; }
        public int StepSeq { get; set; }
        public bool IsOn { get; set; }
        public decimal? Hz { get; set; }
        public Track Track { get; set; }
    }
}
