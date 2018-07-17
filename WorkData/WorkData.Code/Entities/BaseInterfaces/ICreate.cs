// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：ICreate.cs
// 创建标识：吴来伟 2017-12-18 17:35
// 创建描述：
//
// 修改标识：吴来伟2017-12-18 17:35
// 修改描述：
//  ------------------------------------------------------------------------------

using System;

namespace WorkData.Code.Entities.BaseInterfaces
{
    /// <summary>
    /// ICreate
    /// </summary>
    public interface ICreate
    {
        /// <summary>
        /// CreateTime
        /// </summary>
        DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        string CreateUserId { get; set; }
    }
}