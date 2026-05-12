using AutoMapper;
using blog.Dtos;
using blog.Entities.Recipes;
using Microsoft.Extensions.ObjectPool;

namespace blog.Common.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeResponse>()
                .ForMember(dest => dest.MainImageUrl, opt => opt.MapFrom(src => src.RecipeFileMappings.Select(x => x.Files.FileName)));

            CreateMap<Recipe, RecipeDetailResponse>()
                .IncludeBase<Recipe, RecipeResponse>()
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.RecipeTagMappings.Select(x => x.RecipeTag)))
                .ForMember(dest => dest.Steps, opt => opt.MapFrom(src => src.RecipeStepMappings.Select(x => x.RecipeStep)))
                .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.RecipeIngredientsMappings.Select(x => x.RecipeIngredients)))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.RecipeDetailMappings.RecipeDetail.Content));

            CreateMap<RecipeIngredients, Ingredients>()
                .ForMember(dest => dest.IngredientsDetails, opt => opt.MapFrom(src => src.RecipeIngredientsDetailMappings.Select(x => x.RecipeIngredientsDetail)));
            CreateMap<RecipeIngredientsDetail, IngredientsDetail>();

            CreateMap<RecipeStep, Steps>();

            CreateMap<RecipeTag, Tags>();
        }            
    }
}
