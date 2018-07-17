// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Domain.EntityFramework
// 文件名：IWorkDataSessionExtension.cs
// 创建标识：吴来伟 2018-06-22 16:06
// 创建描述：
//
// 修改标识：吴来伟2018-06-22 16:06
// 修改描述：
//  ------------------------------------------------------------------------------

using WorkData.Code.Sessions;

namespace WorkData.Domain.EntityFramework.EntityFramework.Sessions
{
    public interface IWorkDataSessionExtension : IWorkDataSession
    {
        /// <summary>
        /// UserName
        /// </summary>
        string UserName { get; }
    }
}