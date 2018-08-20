// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Domain
// 文件名：WorkDataCms.cs
// 创建标识：吴来伟 2018-06-07 8:53
// 创建描述：
//
// 修改标识：吴来伟2018-06-07 9:16
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Microsoft.EntityFrameworkCore;
using WorkData.Domain.EntityFramework.Mappings.Permissions;
using WorkData.Domain.EntityFramework.Mappings.WeiXin;
using WorkData.Domain.Permissions.Roles;
using WorkData.Domain.Permissions.UserRoles;
using WorkData.Domain.Permissions.Users;
using WorkData.Domain.WeiXin;
using WorkData.EntityFramework;

#endregion

namespace WorkData.Domain.EntityFramework.EntityFramework.Contexts
{
    public class WorkDataContext : WorkDataBaseDbContext
    {
        public WorkDataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BaseUser> BaseUsers { get; set; }

        public DbSet<BaseRole> BaseRoles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<BaseUserMember> BaseUserMembers { get; set; }

        public DbSet<WeiXinShare> WeiXinShare { get; set; }

        /// <summary>
        ///     重写模型创建函数
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BaseUserMap());
            modelBuilder.ApplyConfiguration(new BaseRoleMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
            modelBuilder.ApplyConfiguration(new BaseUserMemberMap());
            modelBuilder.ApplyConfiguration(new WeiXinShareMap());
        }

        /// <summary>
        /// InitDynamicFilters
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void InitDynamicFilters(ModelBuilder modelBuilder)
        {
        }
    }
}