namespace blog.Middleware
{
    public class InternalSecretMiddleware(RequestDelegate next, IConfigurationManager configurationManager)
    {
        private readonly RequestDelegate _next = next;
        private readonly string _secret = configurationManager["Secret:INTERNAL_SECRET"]!;

        public async Task InvokeAsync(HttpContext context)
        {
            var secret = context.Request.Headers["X-Internal-Secret"].FirstOrDefault();
            if (secret != _secret)
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
