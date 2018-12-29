using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WorkData.Dependency;
using WorkData.EntityFramework.Auditables;
using WorkData.Extensions.ServiceCollections;

namespace WorkData.EntityFramework.Extensions
{
    public static class DbContextExtension
    {
        /// <summary>
        /// AddWorkDataDbContext
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <param name="serviceCollection"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static IServiceCollection AddWorkDataDbContext<TContext>(this IServiceCollection serviceCollection, string keyName) where TContext : DbContext
        {
            var dbContextOptions = serviceCollection.ResolveServiceValue<WorkDataDbContextOptions>() ??
                throw new Exception("WorkDataDbContextOptions 不能为空！");

            if (dbContextOptions.WorkDataDbConfigs == null)
                throw new Exception("dbContextOptions.WorkDataDbConfigs 不能为空！");

            var workDataDbConfig = dbContextOptions.WorkDataDbConfigs
                .Single(x => x.KeyName == keyName);

            if (workDataDbConfig == null)
                throw new Exception("workDataDbConfig 不能为空！");

            return serviceCollection.AddDbContext<TContext>(optionsAction =>
            {
                switch (workDataDbConfig.WorkDataDbType)
                {
                    case WorkDataDbType.SqlServer:
                        optionsAction.UseSqlServer(workDataDbConfig.ConnectionString);
                        break;

                    case WorkDataDbType.MySql:
                        throw new ArgumentOutOfRangeException();
                    case WorkDataDbType.PgSql:
                        optionsAction.UseNpgsql(workDataDbConfig.ConnectionString);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
        }

        /// <summary>
        /// 初始化动态审计规则
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection InitAuditable(this IServiceCollection serviceCollection)
        {
            var auditableConfigs = IocManager.ServiceLocatorCurrent.GetInstance<AuditableConfigs>();
            if (AuditableConfigs.AuditableDictionary == null)
            {
                auditableConfigs.InitializedAuditables();
            }

            return serviceCollection;
        }
    }
}