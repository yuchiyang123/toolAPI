using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace blog.Common.Helper
{
    public class JsonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).FirstValue;
            if(value == null) return Task.CompletedTask;

            var result = JsonSerializer.Deserialize(value, bindingContext.ModelType, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
}
