using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Entities.Recipes
{
    [Table("RecipeIngredientsMapping")]
    public class RecipeIngredientsMapping
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int RecipeIngredientsId { get; set; }
        public Recipe Recipe { get; set; }
        public RecipeIngredients RecipeIngredients { get; set; }
    }
}
