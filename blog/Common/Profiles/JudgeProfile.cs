using AutoMapper;
using blog.Dtos.Judge;
using blog.Entities.Judge;

namespace blog.Common.Profiles
{
    public class JudgeProfile : Profile
    {
        public JudgeProfile()
        {
            CreateMap<Problem, BaseProblem>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProblemName))
                .ForMember(
                    dest => dest.PassCount,
                    opt => opt.MapFrom(src => src.Submissions.Sum(x => x.PassedCount))
                )
                .ForMember(
                    dest => dest.TotalCount,
                    opt => opt.MapFrom(src => src.Submissions.Sum(x => x.TotalCount))
                );

            CreateMap<Problem, ProblemsList>().IncludeBase<Problem, BaseProblem>();

            CreateMap<Problem, ProblemDetail>()
                .IncludeBase<Problem, BaseProblem>()
                .ForMember(dest => dest.Submissions, opt => opt.MapFrom(src => src.Submissions));
            CreateMap<Submission, SubmissionDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Users))
                .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.SubmissionResults));
            CreateMap<SubmissionResult, Result>()
                .ForMember(dest => dest.Output, opt => opt.MapFrom(src => src.ActualOutput));
        }
    }
}
