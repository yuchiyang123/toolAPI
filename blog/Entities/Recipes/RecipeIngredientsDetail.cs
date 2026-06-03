using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Entities.Recipes
{
    [Table("RecipeIngredientsDetail")]
    public class RecipeIngredientsDetail
    {
        public int Id { get; set; }
        public required string IngredientsName { get; set; }

        /// <summary>
        /// 需要多少量
        /// </summary>
        public required string Amount { get; set; }
        public ICollection<RecipeIngredientsDetailMapping> RecipeIngredientsDetailMappings { get; set; }
    }
}
