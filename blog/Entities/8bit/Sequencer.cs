using blog.Entities.User;

namespace blog.Entities._8bit
{
    public class Sequencer
    {
        public int Id { get; set; }
        public int Bpm { get; set; }
        public required string Name { get; set; }
        public required DateTime UpdateDate { get; set; }
        public required int UpdateUser { get; set; }
        public required DateTime CreateDate { get; set; }
        public required int CreateUser { get; set; }
        public Users UpdateUsers { get; set; }
        public Users CreateUsers { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
