// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：IAudit.cs
// 创建标识：吴来伟 2017-12-18 17:34
// 创建描述：
//
// 修改标识：吴来伟2017-12-18 17:39
// 修改描述：
//  ------------------------------------------------------------------------------

using WorkData.Code.Entities.BaseInterfaces;

namespace WorkData.Code.Entities
{
    /// <summary>
    ///     审计接口
    /// </summary>
    public interface IAudit : ICreate, IModifier
    {
    }
}