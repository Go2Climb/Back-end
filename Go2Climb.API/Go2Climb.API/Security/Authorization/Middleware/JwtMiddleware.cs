using System.Linq;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Services;
using Go2Climb.API.Security.Authorization.Handlers.Interfaces;
using Go2Climb.API.Security.Authorization.Settings;
using Go2Climb.API.Security.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Go2Climb.API.Security.Authorization.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, ICustomerService customerService, IJwtHandler handler)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var customerId = handler.ValidateToken(token);
            if(customerId != null)
            {
                context.Items["Customers"] = await customerService.GetByIdAsync(customerId.Value);
            }

            await _next(context);
        }
    }
}