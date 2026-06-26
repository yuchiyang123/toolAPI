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
                )
                .ForMember(
                    dest => dest.Tags,
                    opt => opt.MapFrom(src => src.ProblemTags.Select(x => x.Name))
                );

            CreateMap<Problem, ProblemsList>().IncludeBase<Problem, BaseProblem>();

            CreateMap<Problem, ProblemDetail>()
                .IncludeBase<Problem, BaseProblem>()
                .ForMember(dest => dest.Submissions, opt => opt.MapFrom(src => src.Submissions))
                .ForMember(dest => dest.TestCases, opt => opt.MapFrom(src => src.Functions.Take(2)))
                .ForMember(dest => dest.OriginalTestCases, opt => opt.MapFrom(src => src.Functions.Take(2)))
                .ForMember(
                    dest => dest.LanguageInfo,
                    opt => opt.MapFrom(src => src.ProblemSignatures)
                );
            CreateMap<ProblemSignature, LanguageInfo>()
                .ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.Language));
            CreateMap<Function, TestCases>()
                .ForMember(dest => dest.Output, opt => opt.MapFrom(src => src.Expected));
            CreateMap<Submission, SubmissionDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Users))
                .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.SubmissionResults));
            CreateMap<SubmissionResult, Result>()
                .ForMember(dest => dest.Output, opt => opt.MapFrom(src => src.ActualOutput));

            CreateMap<ProblemSignature, ParameterTypeDto>()
                .ForMember(dest => dest.FunctionName, opt => opt.MapFrom(src => src.FunctionName))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
                .ForMember(
                    dest => dest.ParameterTypes,
                    opt => opt.MapFrom(src => src.ProblemParameters)
                )
                .ForMember(
                    dest => dest.ReturnTypes,
                    opt => opt.MapFrom(src => src.ProblemReturnTypes)
                );
            CreateMap<ProblemReturnType, ReturnTypeValue>();
            CreateMap<ProblemParameters, ParameterTypesValue>()
                .ForMember(dest => dest.ParameterType, opt => opt.MapFrom(src => src.Type));

            CreateMap<Problem, SubmissionResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Submissions.First().Id))
                .ForMember(
                    dest => dest.Language,
                    opt => opt.MapFrom(src => src.Functions.First().Language)
                )
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => src.Submissions.First().Status)
                )
                .ForMember(
                    dest => dest.PassedCount,
                    opt => opt.MapFrom(src => src.Submissions.First().PassedCount)
                )
                .ForMember(
                    dest => dest.TotalCount,
                    opt => opt.MapFrom(src => src.Submissions.First().TotalCount)
                )
                .ForMember(dest => dest.ErrorMessage, opt => opt.Ignore())
                .ForMember(
                    dest => dest.Results,
                    opt => opt.MapFrom(src => src.Submissions.First().SubmissionResults)
                )
                .AfterMap(
                    (src, dest) =>
                    {
                        if (dest.Results == null)
                            return;
                        foreach (var item in dest.Results)
                        {
                            item.Input = src.Functions.First(x => x.Id == item.FunctionId).Input;
                            item.Expected = src
                                .Functions.First(x => x.Id == item.FunctionId)
                                .Expected;
                        }
                    }
                );
            CreateMap<SubmissionResult, SubmissionResultDto>()
                .ForMember(dest => dest.Input, opt => opt.Ignore())
                .ForMember(dest => dest.Expected, opt => opt.Ignore());

            CreateMap<TestCasesWithKey, TestCode>();
        }
    }
}
