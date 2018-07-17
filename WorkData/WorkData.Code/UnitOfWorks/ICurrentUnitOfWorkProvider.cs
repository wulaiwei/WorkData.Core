// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Infrastructure
// 文件名：ICurrentUnitOfWorkProvider.cs
// 创建标识：吴来伟 2017-11-27 14:24
// 创建描述：
//
// 修改标识：吴来伟2017-11-27 14:24
// 修改描述：
//  ------------------------------------------------------------------------------

namespace WorkData.Code.UnitOfWorks
{
    /// <summary>
    /// ICurrentUnitOfWorkProvider
    /// </summary>
    public interface ICurrentUnitOfWorkProvider
    {
        /// <summary>
        /// IUnitOfWork
        /// </summary>
        IUnitOfWork Current { get; set; }
    }
}