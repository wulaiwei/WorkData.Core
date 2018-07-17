// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Domain.EntityFramework
// 文件名：UpdateAuditable.cs
// 创建标识：吴来伟 2018-06-08 11:36
// 创建描述：
//
// 修改标识：吴来伟2018-06-08 11:36
// 修改描述：
//  ------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using System;
using WorkData.Code.Entities.BaseInterfaces;
using WorkData.Code.Extensions;
using WorkData.Code.Sessions;

namespace WorkData.EntityFramework.Auditables
{
    [Audit(EntityState.Modified)]
    public class UpdateAuditable : IAuditable
    {
        public void AttemptSetEntityProperty(object entityAsObj, IWorkDataSession workDataSession)
        {
            var entity = entityAsObj.As<IModifier>();
            if (entity == null) return;

            if (string.IsNullOrEmpty(entity.ModifierUserId))
            {
                entity.ModifierUserId = workDataSession.UserId;
            }

            entity.ModifierTime = DateTime.Now;
        }
    }
}