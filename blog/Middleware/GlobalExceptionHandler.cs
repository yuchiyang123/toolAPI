using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace blog.Middleware
{
    /// <summary>
    /// 把常見例外對應成 ProblemDetails，避免 Service 層丟出的 KeyNotFoundException 變成 500。
    /// </summary>
    public sealed class GlobalExceptionHandler(
        IProblemDetailsService problemDetailsService,
        ILogger<GlobalExceptionHandler> logger
    ) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken
        )
        {
            var (status, title) = exception switch
            {
                KeyNotFoundException => (StatusCodes.Status404NotFound, "找不到資源"),
                ArgumentException or FormatException => (
                    StatusCodes.Status400BadRequest,
                    "請求格式錯誤"
                ),
                UnauthorizedAccessException => (StatusCodes.Status403Forbidden, "沒有權限"),
                OperationCanceledException => (499, "請求已取消"),
                _ => (StatusCodes.Status500InternalServerError, "伺服器錯誤"),
            };

            if (status >= 500)
                logger.LogError(
                    exception,
                    "Unhandled exception on {Path}",
                    httpContext.Request.Path
                );
            else
                logger.LogWarning(
                    exception,
                    "Handled exception on {Path}",
                    httpContext.Request.Path
                );

            httpContext.Response.StatusCode = status;

            return await problemDetailsService.TryWriteAsync(
                new ProblemDetailsContext
                {
                    HttpContext = httpContext,
                    Exception = exception,
                    ProblemDetails = new ProblemDetails
                    {
                        Status = status,
                        Title = title,
                        Detail = status >= 500 ? null : exception.Message,
                    },
                }
            );
        }
    }
}
