// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Infrastructure
// 文件名：IUnitOfWorkManager.cs
// 创建标识：吴来伟 2017-11-27 14:25
// 创建描述：
//
// 修改标识：吴来伟2017-11-27 14:25
// 修改描述：
//  ------------------------------------------------------------------------------

using System;

namespace WorkData.Code.UnitOfWorks
{
    /// <summary>
    /// IUnitOfWorkManager
    /// </summary>
    public interface IUnitOfWorkManager : IDisposable
    {
        /// <summary>
        /// Gets currently active unit of work (or null if not exists).
        /// </summary>
        IActiveUnitOfWork Current { get; }

        /// <summary>
        /// Begins a new unit of work.
        /// </summary>
        /// <returns>A handle to be able to complete the unit of work</returns>
        IUnitOfWorkCompleteHandle Begin();
    }
}