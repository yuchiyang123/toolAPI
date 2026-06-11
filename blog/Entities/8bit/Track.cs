namespace blog.Entities._8bit
{
    public class Track
    {
        public int Id { get; set; }
        public int SequencerId { get; set; }
        public int StepId { get; set; }
        public int TrackSeq { get; set; }
        public Sequencer Sequencer { get; set; }
        public List<Step> Step { get; set; }
    }
}
