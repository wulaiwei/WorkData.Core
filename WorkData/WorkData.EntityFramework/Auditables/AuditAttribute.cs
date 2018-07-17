// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.EntityFramework
// 文件名：AuditAttribute.cs
// 创建标识：吴来伟 2018-06-08 10:44
// 创建描述：
//
// 修改标识：吴来伟2018-06-08 10:44
// 修改描述：
//  ------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using System;

namespace WorkData.EntityFramework.Auditables
{
    public class AuditAttribute : Attribute
    {
        public AuditAttribute(EntityState entityState)
        {
            EntityState = entityState;
        }

        public EntityState EntityState { get; set; }
    }
}