// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Infrastructure
// 文件名：IActiveUnitOfWork.cs
// 创建标识：吴来伟 2017-11-27 11:04
// 创建描述：
//
// 修改标识：吴来伟2017-11-27 11:04
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Threading.Tasks;

namespace WorkData.Code.UnitOfWorks
{
    /// <summary>
    /// IActiveUnitOfWork
    /// </summary>
    public interface IActiveUnitOfWork
    {
        /// <summary>
        /// Saves all changes until now in this unit of work.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Saves all changes until now in this unit of work.
        /// </summary>
        Task SaveChangesAsync();
    }
}