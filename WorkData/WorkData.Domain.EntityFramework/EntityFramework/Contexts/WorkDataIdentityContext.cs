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
using System;
using System.Linq;
using WorkData.Domain.EntityFramework.Mappings.Permissions;
using WorkData.Domain.Permissions.Roles;
using WorkData.Domain.Permissions.Users;
using WorkData.EntityFramework;
using WorkData.EntityFramework.Auditables;

#endregion

namespace WorkData.Domain.EntityFramework.EntityFramework.Contexts
{
    public class WorkDataIdentityContext : WorkDataBaseDbContext
    {
        public DbSet<BaseUser> BaseUsers { get; set; }

        public DbSet<BaseRole> BaseRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

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
        }

        /// <summary>
        /// SaveChange
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            //过滤所有修改了的实体，包括：增加 / 修改 / 删除
            var objectStateEntryList = ChangeTracker.Entries().Where(obj => obj.State != EntityState.Unchanged);
            foreach (var entry in objectStateEntryList)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        AuditableConfigs.AuditableDictionary[EntityState.Added].ForEach(x =>
                        {
                            x.AttemptSetEntityProperty(entry.Entity, WorkDataSession);
                        });
                        break;

                    case EntityState.Deleted:
                        AuditableConfigs.AuditableDictionary[EntityState.Deleted].ForEach(x =>
                        {
                            x.AttemptSetEntityProperty(entry.Entity, WorkDataSession);
                        });
                        break;

                    case EntityState.Modified:
                        AuditableConfigs.AuditableDictionary[EntityState.Modified].ForEach(x =>
                        {
                            x.AttemptSetEntityProperty(entry.Entity, WorkDataSession);
                        });
                        break;

                    case EntityState.Detached:
                        break;

                    case EntityState.Unchanged:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return base.SaveChanges();
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