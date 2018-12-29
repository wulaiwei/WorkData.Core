using Microsoft.AspNetCore.Mvc.Filters;
using WorkData.BaseWeb.Extension;
using WorkData.Code.UnitOfWorks;

namespace WorkData.BaseWeb.Filters
{
    public class WebUowFilter : IActionFilter
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public WebUowFilter(IUnitOfWorkManager unitOfWorkManager)
        {
            _unitOfWorkManager = unitOfWorkManager;
        }

        public IUnitOfWorkCompleteHandle UnitOfWorkCompleteHandle { get; set; }

        /// <summary>
        ///     OnActionExecuting
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var unitOfWorkAttribute = context.TypeOfAttributeEntity<UnitOfWorkAttribute>();
            if (unitOfWorkAttribute != null && unitOfWorkAttribute.IsDisabled)
                return;
            UnitOfWorkCompleteHandle = _unitOfWorkManager.Begin();
        }

        /// <summary>
        ///     OnActionExecuted
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            UnitOfWorkCompleteHandle?.Complate();
        }
    }
}