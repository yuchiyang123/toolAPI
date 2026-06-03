using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Entities.Recipes
{
    [Table("RecipeDetail")]
    public class RecipeDetail
    {
        public int Id { get; set; }

        /// <summary>
        /// 心得
        /// </summary>
        public required string Content { get; set; }
        public ICollection<RecipeDetail> RecipeDetails { get; set; }
    }
}
