using Azure.Core;

namespace Shoppie.Middleware
{
    public class AssignCookieMiddleware
    {
        private readonly RequestDelegate _next;

        public AssignCookieMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Cookies["UserId"] is null)
            {
                context.Response.Cookies.Append("UserId", Guid.NewGuid().ToString());
            }
            await _next(context);
        }


    }
}
