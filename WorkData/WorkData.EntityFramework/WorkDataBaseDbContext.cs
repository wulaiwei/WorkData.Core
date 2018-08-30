#region

using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
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
        ///     ClaimsPrincipal
        /// </summary>
        public ClaimsPrincipal ClaimsPrincipal { get; set; }

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
                            x.AttemptSetEntityProperty(entry.Entity, WorkDataSession, ClaimsPrincipal);
                        });
                        break;

                    case EntityState.Deleted:
                        AuditableConfigs.AuditableDictionary[EntityState.Deleted].ForEach(x =>
                        {
                            x.AttemptSetEntityProperty(entry.Entity, WorkDataSession, ClaimsPrincipal);
                        });
                        break;

                    case EntityState.Modified:
                        AuditableConfigs.AuditableDictionary[EntityState.Modified].ForEach(x =>
                        {
                            x.AttemptSetEntityProperty(entry.Entity, WorkDataSession, ClaimsPrincipal);
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