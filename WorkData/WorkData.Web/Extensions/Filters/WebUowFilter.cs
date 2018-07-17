// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Web
// 文件名：WebUowFilterAttribute.cs
// 创建标识：吴来伟 2018-06-07 16:26
// 创建描述：
//
// 修改标识：吴来伟2018-06-07 16:26
// 修改描述：
//  ------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc.Filters;
using WorkData.Code.UnitOfWorks;

namespace WorkData.Web.Extensions.Filters
{
    public class WebUowFilter : IActionFilter
    {
        public IUnitOfWorkCompleteHandle UnitOfWorkCompleteHandle { get; set; }
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public WebUowFilter(IUnitOfWorkManager unitOfWorkManager)
        {
            _unitOfWorkManager = unitOfWorkManager;
        }

        /// <summary>
        /// OnActionExecuting
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            UnitOfWorkCompleteHandle = _unitOfWorkManager.Begin();
        }

        /// <summary>
        /// OnActionExecuted
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            UnitOfWorkCompleteHandle.Complate();
        }
    }
}