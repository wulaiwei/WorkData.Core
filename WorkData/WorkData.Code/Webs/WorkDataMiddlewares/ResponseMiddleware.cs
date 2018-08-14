#region

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

#endregion

namespace WorkData.Code.Webs.WorkDataMiddlewares
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