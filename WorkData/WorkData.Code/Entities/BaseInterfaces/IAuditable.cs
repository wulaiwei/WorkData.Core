// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：IAuditable.cs
// 创建标识：吴来伟 2017-12-21 15:24
// 创建描述：
//
// 修改标识：吴来伟2017-12-21 15:24
// 修改描述：
//  ------------------------------------------------------------------------------

using WorkData.Code.Sessions;

namespace WorkData.Code.Entities.BaseInterfaces
{
    /// <summary>
    /// IAuditable
    /// </summary>
    public interface IAuditable
    {
        /// <summary>
        /// AttemptSetEntityProperty
        /// </summary>
        void AttemptSetEntityProperty(object entityAsObj, IWorkDataSession workDataSession);
    }
}