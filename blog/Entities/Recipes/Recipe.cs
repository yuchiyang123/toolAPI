using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Entities.Recipes
{
    [Table("Recipe")]
    public class Recipe
    {
        public int Id { get; set; }

        /// <summary>
        /// 食譜名稱
        /// </summary>
        public required string RecipeName { get; set; }

        /// <summary>
        /// 份數
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 烹飪時間
        /// </summary>
        public int CookingTime { get; set; }

        /// <summary>
        /// 烹飪複雜度(1簡單~5複雜)
        /// </summary>
        public int Complexity { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string? Description { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<RecipeTagMapping> RecipeTagMappings { get; set; }
        public ICollection<RecipeStepMapping> RecipeStepMappings { get; set; }
        public RecipeDetailMapping RecipeDetailMappings { get; set; }
        public ICollection<RecipeIngredientsMapping> RecipeIngredientsMappings { get; set; }
        public RecipeFileMapping RecipeFileMappings { get; set; }
    }
}
