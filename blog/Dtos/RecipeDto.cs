using blog.Dtos.Page;

namespace blog.Dtos
{

    #region 食譜Response
    public class RecipeResponse
    {
        public int Id { get; init; }
        /// <summary>
        /// 食譜名稱
        /// </summary>
        public required string RecipeName { get; init; }
        /// <summary>
        /// 烹飪時間(分鐘)
        /// </summary>
        public required int CookingTime { get; init; }
        /// <summary>
        /// 難易度(1分簡單~5分困難)
        /// </summary>
        public int Complexity { get; init; }
        /// <summary>
        /// 最後更新時間
        /// </summary>
        public DateTime UpdateDate { get; init; }
    }

    public class RecipeDetailResponse : RecipeResponse
    {
        /// <summary>
        /// 總共多少份
        /// </summary>
        public required int TotalAmount { get; init; }
        /// <summary>
        /// 描述，筆記
        /// </summary>
        public required string Description { get; init; }
        /// <summary>
        /// 詳細內容
        /// </summary>
        public required string Content { get; init; }
        /// <summary>
        /// 食材
        /// </summary>
        public required List<Ingredients> Ingredients { get; init; }
        /// <summary>
        /// 食譜步驟
        /// </summary>
        public required List<Steps> Steps { get; init; }
        /// <summary>
        /// 食譜標籤
        /// </summary>
        public List<Tags>? Tags { get; init; }
    }

    public class Ingredients
    {
        /// <summary>
        /// 食材群組名稱
        /// </summary>
        public required string IngredientsGroupName { get; init; }
        /// <summary>
        /// 食材細節
        /// </summary>
        public required List<IngredientsDetail> IngredientsDetails { get; init; }
    }

    public class IngredientsDetail
    {
        /// <summary>
        /// 食材名稱
        /// </summary>
        public required string IngredientsName { get; init; }
        /// <summary>
        /// 食材用量
        /// </summary>
        public required string Amount { get; init; }
    }

    public class Steps
    {
        /// <summary>
        /// 第幾步驟
        /// </summary>
        public required int Step { get; init; }
        /// <summary>
        /// 步驟說明
        /// </summary>
        public required string Description { get; init; }
    }

    public class Tags
    {
        public required string Tag { get; set; }
    }
    #endregion

    #region 食譜查詢 Query Dto
    public class RecipeQueryDto : PageQueryDto { }
    #endregion

    #region 食譜新增 Request Dto
    public class RecipeRequest
    {
        /// <summary>
        /// 食譜名稱
        /// </summary>
        public required string RecipeName { get; init; }
        /// <summary>
        /// 烹飪時間(分鐘)
        /// </summary>
        public required int CookingTime { get; init; }
        /// <summary>
        /// 難易度(1分簡單~5分困難)
        /// </summary>
        public int Complexity { get; init; }
        /// <summary>
        /// 最後更新時間
        /// </summary>
        public DateTime UpdateDate { get; init; }
        /// <summary>
        /// 總共多少份
        /// </summary>
        public required int TotalAmount { get; init; }
        /// <summary>
        /// 描述，筆記
        /// </summary>
        public required string Description { get; init; }
        /// <summary>
        /// 詳細內容
        /// </summary>
        public required string Content { get; init; }
        /// <summary>
        /// 食材
        /// </summary>
        public required List<Ingredients> Ingredients { get; init; }
        /// <summary>
        /// 食譜步驟
        /// </summary>
        public required List<Steps> Steps { get; init; }
        /// <summary>
        /// 食譜標籤
        /// </summary>
        public List<Tags>? Tags { get; init; }
    }
    #endregion
}
