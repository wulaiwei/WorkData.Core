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
using WorkData.Code.Sessions;
using WorkData.Dependency;
using WorkData.EntityFramework.Auditables;

#endregion

namespace WorkData.EntityFramework
{
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
        /// Used to get current session values.
        /// </summary>
        public IWorkDataSession WorkDataSession { get; set; }

        /// <summary>
        /// WorkDataDbConfig
        /// </summary>
        public WorkDataDbConfig WorkDataDbConfig { get; set; } =
            IocManager.Instance.ResolveServiceValue<WorkDataDbConfig>();

        /// <summary>
        /// OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder"></param>
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
            //默认移除级联删除
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 动态数据筛选器
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected abstract void InitDynamicFilters(ModelBuilder modelBuilder);
    }
}