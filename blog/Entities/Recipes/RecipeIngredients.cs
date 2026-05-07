using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Entities.Recipes
{
    [Table("RecipeIngredients")]
    public class RecipeIngredients
    {
        public int Id { get; set; }
        public required string IngredientsGroupName { get; set; }
        public ICollection<RecipeDetailMapping> RecipeDetailMappings { get; set; }
        public ICollection<RecipeIngredientsMapping> RecipeIngredientsMappings { get; set; }
        public ICollection<RecipeIngredientsDetailMapping> RecipeIngredientsDetailMappings { get; set; }
    }
}
