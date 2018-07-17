// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Infrastructure
// 文件名：UnitOfWorkInterceptor.cs
// 创建标识：吴来伟 2017-11-27 15:01
// 创建描述：
//
// 修改标识：吴来伟2017-11-27 15:01
// 修改描述：
//  ------------------------------------------------------------------------------

using Castle.DynamicProxy;
using WorkData.Code.Helpers;

namespace WorkData.Code.UnitOfWorks
{
    /// <summary>
    /// 自动工作单元（AOP）
    /// </summary>
    public class UnitOfWorkInterceptor : IInterceptor
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UnitOfWorkInterceptor(IUnitOfWorkManager unitOfWorkManager)
        {
            _unitOfWorkManager = unitOfWorkManager;
        }

        /// <summary>
        /// Intercept
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            if (AsyncHelper.IsAsyncMethod(invocation.Method))
            {
                PerformUowAsync(invocation);
            }
            else
            {
                PerformUow(invocation);
            }
        }

        /// <summary>
        /// PerformUow
        /// </summary>
        /// <param name="invocation"></param>
        private void PerformUow(IInvocation invocation)
        {
            using (var uow = _unitOfWorkManager.Begin())
            {
                invocation.Proceed();
                uow.Complate();
            }
        }

        /// <summary>
        /// PerformUow
        /// </summary>
        /// <param name="invocation"></param>
        private void PerformUowAsync(IInvocation invocation)
        {
            using (var uow = _unitOfWorkManager.Begin())
            {
                invocation.Proceed();
                uow.CompleteAsync();
            }
        }
    }
}