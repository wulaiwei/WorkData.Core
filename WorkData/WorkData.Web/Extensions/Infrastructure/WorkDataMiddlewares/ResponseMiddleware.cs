// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Web
// 文件名：ResponseMiddleware.cs
// 创建标识：吴来伟 2018-06-20 10:14
// 创建描述：
//
// 修改标识：吴来伟2018-06-21 13:57
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

#endregion

namespace WorkData.Web.Extensions.Infrastructure.WorkDataMiddlewares
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