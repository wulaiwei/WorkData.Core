// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Web
// 文件名：WorkDataExpectionFilter.cs
// 创建标识：吴来伟 2018-06-21 15:11
// 创建描述：
//
// 修改标识：吴来伟2018-06-21 15:50
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using WorkData.Code.ResponseExtensions;
using WorkData.Util.Common.ExceptionExtensions;

#endregion

namespace WorkData.Web.Extensions.Filters
{
    public class WorkDataExpectionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (!(context.ActionDescriptor is ControllerActionDescriptor))
            {
                return;
            }

            if (!(context.Exception is UserFriendlyException))
                return;
            var serverResponse = ResponseProvider.Error(default(BaseResponseEmpty), context.Exception.Message);

            context.Result = new BadRequestObjectResult(serverResponse);

            context.Exception = null;
        }
    }
}