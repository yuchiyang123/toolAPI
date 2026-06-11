using AutoMapper;
using blog.Dtos;
using blog.Dtos._8bit;
using blog.Entities._8bit;

namespace blog.Common.Profiles
{
    public class _8bitProfile : Profile
    {
        public _8bitProfile()
        {
            #region Base
            CreateMap<Sequencer, BaseSequencer>().ReverseMap();
            CreateMap<Track, BaseTrack>()
                .ForMember(dest => dest.Seq, opt => opt.MapFrom(src => src.TrackSeq)).ReverseMap();
            CreateMap<Step, BaseStep>()
                .ForMember(dest => dest.Seq, opt => opt.MapFrom(src => src.StepSeq)).ReverseMap();
            #endregion

            #region Request
            CreateMap<SequencerRequestDto, Sequencer>()
                .ForMember(dest => dest.Tracks, opt => opt.MapFrom(src => src.Tracks))
                .IncludeBase<BaseSequencer, Sequencer>();
            CreateMap<TrackRequestDto, Track>()
                .ForMember(dest => dest.Step, opt => opt.MapFrom(src => src.Steps))
                .IncludeBase<BaseTrack, Track>();
            CreateMap<StepRequestDto, Step>()
                .IncludeBase<BaseStep, Step>();
            #endregion

            #region Response
            CreateMap<Sequencer, SequencerListRequestDto>()
                .IncludeBase<Sequencer, BaseSequencer>();

            CreateMap<Sequencer, SequencerResponseDto>()
                .ForMember(dest => dest.Tracks, opt => opt.MapFrom(src => src.Tracks))
                .IncludeBase<Sequencer, BaseSequencer>();
            CreateMap<Track, TrackResponseDto>()
                .ForMember(dest => dest.Steps, opt => opt.MapFrom(src => src.Step))
                .IncludeBase<Track, BaseTrack>();
            CreateMap<Step, StepResponseDto>()
                .IncludeBase<Step, BaseStep>();
            #endregion
        }
    }
}
