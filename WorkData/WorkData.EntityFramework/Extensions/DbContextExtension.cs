using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
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
        /// <returns></returns>
        public static IServiceCollection AddWorkDataDbContext<TContext>(this IServiceCollection serviceCollection) where TContext : DbContext
        {
            var workDataDbConfig = serviceCollection.ResolveServiceValue<WorkDataDbConfig>();

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
            serviceCollection.AddSingleton<AuditableConfigs>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var auditableConfigs = serviceProvider.GetService<AuditableConfigs>();
            if (AuditableConfigs.AuditableDictionary == null)
            {
                auditableConfigs.InitializedAuditables();
            }

            return serviceCollection;
        }
    }
}