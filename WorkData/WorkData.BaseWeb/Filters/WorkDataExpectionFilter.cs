#region

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using WorkData.Code.ResponseExtensions;
using WorkData.Util.Common.ExceptionExtensions;

#endregion

namespace WorkData.BaseWeb.Filters
{
    /// <summary>
    /// WorkDataExpectionFilter
    /// </summary>
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