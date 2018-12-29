using Microsoft.AspNetCore.Builder;

namespace WorkData.BaseWeb.WorkDataMiddlewares
{
    public static class WorkDataMiddlewareExtension
    {
        public static IApplicationBuilder UseResponse(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BaseWeb.WorkDataMiddlewares.ResponseMiddleware>();
        }
    }
}