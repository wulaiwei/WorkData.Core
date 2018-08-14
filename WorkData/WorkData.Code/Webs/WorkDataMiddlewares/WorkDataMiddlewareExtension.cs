using Microsoft.AspNetCore.Builder;

namespace WorkData.Code.Webs.WorkDataMiddlewares
{
    public static class WorkDataMiddlewareExtension
    {
        public static IApplicationBuilder UseResponse(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseMiddleware>();
        }
    }
}