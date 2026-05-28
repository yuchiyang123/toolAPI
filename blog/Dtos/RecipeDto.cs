using blog.Common.Helper;
using blog.Dtos.Page;
using Microsoft.AspNetCore.Mvc;

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
        /// 主要的圖片
        /// </summary>
        public string? MainImageUrl { get; set; }
        /// <summary>
        /// 最後更新時間
        /// </summary>
        public DateTime UpdateDate { get; init; }
        /// <summary>
        /// 食譜標籤
        /// </summary>
        public List<Tags>? Tags { get; init; }
        /// <summary>
        /// 描述，筆記
        /// </summary>
        public required string Description { get; init; }
    }

    public class RecipeDetailResponse : RecipeResponse
    {
        /// <summary>
        /// 總共多少份
        /// </summary>
        public required int TotalAmount { get; init; }
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
        /// 圖片
        /// </summary>
        public IFormFile? MailImage { get; set; }
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
        [ModelBinder(BinderType = typeof(JsonModelBinder))]
        public required List<Ingredients> Ingredients { get; init; }
        /// <summary>
        /// 食譜步驟
        /// </summary>
        [ModelBinder(BinderType = typeof(JsonModelBinder))]
        public required List<Steps> Steps { get; init; }
        /// <summary>
        /// 食譜標籤
        /// </summary>
        [ModelBinder(BinderType = typeof(JsonModelBinder))]
        public List<Tags>? Tags { get; init; }
    }
    #endregion

    #region 食譜更新 Request Dto
    public class UpdateSteps : Steps
    {
        public int Id { get; set; }
    }

    public class UpdateTags : Tags
    {
        public int Id { get; set; }
    }

    public class UpdateIngredients
    {
        public int Id { get; set; }
        /// <summary>
        /// 食材群組名稱
        /// </summary>
        public required string IngredientsGroupName { get; init; }
        /// <summary>
        /// 食材細節
        /// </summary>
        public required List<UpdateIngredientsDetail> IngredientsDetails { get; init; }
    }

    public class UpdateIngredientsDetail : IngredientsDetail
    {
        public int Id { get; set; }
    }

    public class RecipeUpdateRequest
    {
        /// <summary>
        /// 圖片
        /// </summary>
        public IFormFile? MailImage { get; set; }
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
        [ModelBinder(BinderType = typeof(JsonModelBinder))]
        public required List<UpdateIngredients> Ingredients { get; init; }
        /// <summary>
        /// 食譜步驟
        /// </summary>
        [ModelBinder(BinderType = typeof(JsonModelBinder))]
        public required List<UpdateSteps> Steps { get; init; }
        /// <summary>
        /// 食譜標籤
        /// </summary>
        [ModelBinder(BinderType = typeof(JsonModelBinder))]
        public List<UpdateTags>? Tags { get; init; }
    }
    #endregion 
}
