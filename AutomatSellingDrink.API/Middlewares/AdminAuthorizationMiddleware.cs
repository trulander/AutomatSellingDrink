using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AutomatSellingDrink.API.Middlewares
{
    public class AdminAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
 
        public AdminAuthorizationMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["admin"];
            if (token!="12345678")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Admin unauthorized");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}