// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：IModifier.cs
// 创建标识：吴来伟 2017-12-18 17:37
// 创建描述：
//
// 修改标识：吴来伟2017-12-18 17:37
// 修改描述：
//  ------------------------------------------------------------------------------

using System;

namespace WorkData.Code.Entities.BaseInterfaces
{
    /// <summary>
    /// IModifier
    /// </summary>
    public interface IModifier
    {
        /// <summary>
        /// 编辑时间
        /// </summary>
        DateTime? ModifierTime { get; set; }

        /// <summary>
        /// 编辑用户
        /// </summary>
        string ModifierUserId { get; set; }
    }
}