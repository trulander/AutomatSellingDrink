using System.Linq;
using System.Threading.Tasks;
using AutomatSellingDrink.API.Contracts;
using AutomatSellingDrink.API.Extensions;
using AutomatSellingDrink.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace AutomatSellingDrink.API.Middlewares
{
    public class AutenticationUserMidleware
    {
        private readonly RequestDelegate _next;

        public AutenticationUserMidleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, IUserService userService)
        {
            if (!context.Session.Keys.Contains("user"))
            {
                var user = await userService.CreateUser(context.Session.Id);
                context.Session.Set<Core.Models.User>("user", user);
            }
            await _next.Invoke(context);

        }
    }
}