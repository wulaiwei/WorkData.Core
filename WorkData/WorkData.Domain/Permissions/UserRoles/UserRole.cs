// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Domain
// 文件名：UserRole.cs
// 创建标识：吴来伟 2018-06-07 14:36
// 创建描述：
//
// 修改标识：吴来伟2018-06-07 14:36
// 修改描述：
//  ------------------------------------------------------------------------------

using WorkData.Domain.Permissions.Roles;
using WorkData.Domain.Permissions.Users;

namespace WorkData.Domain.Permissions.UserRoles
{
    /// <summary>
    /// UserRole
    /// </summary>
    public class UserRole
    {
        public string BaseUserId { get; set; }

        public BaseUser BaseUser { get; set; }

        public string BaseRoleId { get; set; }

        public BaseRole BaseRole { get; set; }
    }
}