// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：Domain.Core
// 文件名：BaseRole.cs
// 创建标识：吴来伟 2017-12-19 13:47
// 创建描述：
//
// 修改标识：吴来伟2017-12-19 13:47
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Collections.Generic;
using WorkData.Code.Entities;
using WorkData.Code.Repositories;
using WorkData.Code.WorkDataIdentity;
using WorkData.Domain.Permissions.UserRoles;

namespace WorkData.Domain.Permissions.Roles
{
    /// <summary>
    /// 基础RoleBase
    /// </summary>
    public class BaseRole : BaseRoleIdentity<string>, IEntity<string>, IAggregateRoot
    {
        /// <summary>
        /// Id
        /// </summary>
        public override string Id { get; set; }

        /// <summary>
        /// 角色代码
        /// </summary>
        public string Code { get; set; }

        public IList<UserRole> UserRoles { get; set; }
    }
}