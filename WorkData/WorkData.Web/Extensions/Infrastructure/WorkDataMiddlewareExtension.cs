using Microsoft.AspNetCore.Builder;
using WorkData.Web.Extensions.Infrastructure.WorkDataMiddlewares;

namespace WorkData.Web.Extensions.Infrastructure
{
    public static class WorkDataMiddlewareExtension
    {
        public static IApplicationBuilder UseResponse(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseMiddleware>();
        }
    }
}