// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Infrastructure
// 文件名：IUnitOfWorkCompleteHandle.cs
// 创建标识：吴来伟 2017-11-27 14:28
// 创建描述：
//
// 修改标识：吴来伟2017-11-27 14:28
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace WorkData.Code.UnitOfWorks
{
    /// <summary>
    /// IUnitOfWorkCompleteHandle
    /// </summary>
    public interface IUnitOfWorkCompleteHandle : IDisposable
    {
        /// <summary>
        /// Complate
        /// </summary>
        void Complate();

        /// <summary>
        /// CompleteAsync
        /// </summary>
        /// <returns></returns>
        Task CompleteAsync();
    }
}