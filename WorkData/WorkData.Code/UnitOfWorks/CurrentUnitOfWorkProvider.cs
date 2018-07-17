// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Infrastructure
// 文件名：CurrentUnitOfWorkProvider.cs
// 创建标识：吴来伟 2017-11-27 14:45
// 创建描述：
//
// 修改标识：吴来伟2017-11-27 14:45
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using System.Threading;

namespace WorkData.Code.UnitOfWorks
{
    /// <summary>
    /// CurrentUnitOfWorkProvider
    /// </summary>
    public class CurrentUnitOfWorkProvider : ICurrentUnitOfWorkProvider
    {
        private static readonly AsyncLocal<IUnitOfWork> AsyncLocalUow = new AsyncLocal<IUnitOfWork>();

        public IUnitOfWork Current
        {
            get => GetUnitOfWork();
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                SetUnitOfWork(value);
            }
        }

        /// <summary>
        /// SetUnitOfWork
        /// </summary>
        /// <param name="value"></param>
        private static void SetUnitOfWork(IUnitOfWork value)
        {
            lock (AsyncLocalUow)
            {
                AsyncLocalUow.Value = value;
            }
        }

        /// <summary>
        /// GetUnitOfWork
        /// </summary>
        /// <returns></returns>
        private static IUnitOfWork GetUnitOfWork()
        {
            return AsyncLocalUow.Value ?? null;
        }
    }
}