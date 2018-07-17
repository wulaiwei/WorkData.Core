// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Util.Common
// 文件名：WorkDataBaseInterceptor.cs
// 创建标识：吴来伟 2018-06-06 16:24
// 创建描述：
//
// 修改标识：吴来伟2018-06-06 16:24
// 修改描述：
//  ------------------------------------------------------------------------------

using Castle.DynamicProxy;
using Polly;
using System;

namespace WorkData.Util.Common.Interceptors
{
    /// <inheritdoc />
    /// <summary>
    ///     WorkDataBaseInterceptor
    /// </summary>
    public class WorkDataBaseInterceptor : IInterceptor
    {
        /// <summary>
        ///     完成任务 （不考虑成功失败）
        /// </summary>
        public Action<IInvocation> Complate { get; set; }

        /// <summary>
        ///     异常任务
        /// </summary>
        public Action<Exception> Error { get; set; }

        /// <summary>
        ///     重试次数
        /// </summary>
        public int RetryCount { get; set; } = 0;

        /// <summary>
        ///     Intercept
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            try
            {
                //需设置为Config
                var retryPolicy =
                    Policy
                        .Handle<Exception>()
                        .Retry(RetryCount);

                retryPolicy
                    .Execute(invocation.Proceed);
            }
            catch (Exception e)
            {
                Error?.Invoke(e);
            }
            finally
            {
                Complate?.Invoke(invocation);
            }
        }
    }
}