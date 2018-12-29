#region

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

#endregion

namespace WorkData.BaseWeb.WorkDataMiddlewares
{
    public class ResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            var reponse = context.Response;
        }
    }
}