namespace blog.Dtos._8bit
{
    public abstract class BaseSequencer
    {
        public required int Bpm { get; set; }
        public required string Name { get; set; }
    }

    public abstract class BaseTrack
    {
        public int Seq { get; set; }
    }

    public abstract class BaseStep
    {
        public required int Seq { get; set; }
        public required bool IsOn { get; set; }
        public decimal? Hz { get; set; }
    }

    #region return Response
    public class SequencerResponseDto : BaseSequencer
    {
        public int Id { get; set; }
        public required List<TrackResponseDto> Tracks { get; set; }
        public UserDto? UpdateUser { get; set; }
        public UserDto? CreateUser { get; set; }
    }

    public class TrackResponseDto : BaseTrack
    {
        public int Id { get; set; }
        public required List<StepResponseDto> Steps { get; set; }
    }

    public class StepResponseDto : BaseStep
    {
        public int Id { get; set; }
    }
    #endregion

    #region Request
    public class SequencerRequestDto : BaseSequencer
    {
        public required List<TrackRequestDto> Tracks { get; set; }
    }

    public class TrackRequestDto : BaseTrack
    {
        public required List<StepRequestDto> Steps { get; set; }
    }

    public class StepRequestDto : BaseStep { }

    public class SequencerListRequestDto : BaseSequencer { }
    #endregion
}
