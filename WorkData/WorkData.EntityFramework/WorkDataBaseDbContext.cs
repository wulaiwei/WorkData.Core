// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.EntityFramework
// 文件名：WorkDataDbContext.cs
// 创建标识：吴来伟 2017-12-05 9:36
// 创建描述：
//
// 修改标识：吴来伟2017-12-05 10:13
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WorkData.Code.Sessions;
using WorkData.EntityFramework.Auditables;

#endregion

namespace WorkData.EntityFramework
{
    /// <inheritdoc />
    /// <summary>
    ///     WorkDataDbContext
    /// </summary>
    public abstract class WorkDataBaseDbContext : DbContext
    {
        protected WorkDataBaseDbContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        ///     WorkDataSession
        /// </summary>
        public IWorkDataSession WorkDataSession { get; set; }

        /// <summary>
        ///     SaveChange
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            #region 过滤所有修改了的实体，包括：增加 / 修改 / 删除

            var objectStateEntryList = ChangeTracker.Entries().Where(obj => obj.State != EntityState.Unchanged);
            foreach (var entry in objectStateEntryList)
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

            #endregion

            return base.SaveChanges();
        }

        /// <summary>
        ///     动态数据筛选器
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected abstract void InitDynamicFilters(ModelBuilder modelBuilder);
    }
}