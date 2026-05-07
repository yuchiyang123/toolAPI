using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Entities.Recipes
{
    [Table("RecipeIngredientsDetailMapping")]
    public class RecipeIngredientsDetailMapping
    {
        public int Id { get; set; }
        public int RecipeIngredientId { get; set; }
        public int RecipeIngredientDetailId { get; set; }
        public RecipeIngredients RecipeIngredient { get; set; }
        public RecipeIngredientsDetail RecipeIngredientsDetail { get; set; }
    }
}
