// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Infrastructure
// 文件名：IUnitOfWork.cs
// 创建标识：吴来伟 2017-11-27 10:59
// 创建描述：
//
// 修改标识：吴来伟2017-11-27 15:07
// 修改描述：
//  ------------------------------------------------------------------------------

#region

#endregion

namespace WorkData.Code.UnitOfWorks
{
    /// <summary>
    ///     IUnitOfWork
    /// </summary>
    public interface IUnitOfWork : IActiveUnitOfWork, IUnitOfWorkCompleteHandle
    {
        /// <summary>
        ///     Begins the unit of work with given options.
        /// </summary>
        void Begin();
    }
}