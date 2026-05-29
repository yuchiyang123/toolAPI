namespace blog.Middleware
{
    public class InternalSecretMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            var secret = context.Request.Headers["X-Internal-Secret"].FirstOrDefault();
            if (secret != Environment.GetEnvironmentVariable("INTERNAL_SECRET"))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Unauthorized");                
            }
            else
            {
                await _next(context);
            }
        }
    }
}
