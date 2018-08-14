using Microsoft.AspNetCore.Mvc.Filters;
using WorkData.Code.UnitOfWorks;
using WorkData.Code.Webs.Extension;

namespace WorkData.Code.Webs.Filters
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