// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：UnitOfWorkAttribute.cs
// 创建标识：吴来伟 2018-06-23 21:33
// 创建描述：
//
// 修改标识：吴来伟2018-06-23 21:33
// 修改描述：
//  ------------------------------------------------------------------------------

using System;

namespace WorkData.Code.UnitOfWorks
{
    /// <summary>
    /// UnitOfWorkAttribute
    /// </summary>
    public class UnitOfWorkAttribute : Attribute
    {
        public bool IsDisabled { get; set; } = true;
    }
}