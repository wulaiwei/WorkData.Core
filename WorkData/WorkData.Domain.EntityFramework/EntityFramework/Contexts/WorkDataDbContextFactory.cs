using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WorkData.EntityFramework;
using WorkData.Extensions.ServiceCollections;

namespace WorkData.Domain.EntityFramework.EntityFramework.Contexts
{
    public class WorkDataDbContextFactory : IDesignTimeDbContextFactory<WorkDataContext>
    {
        /// <summary>
        ///     ServiceCollection
        /// </summary>
        public IServiceCollection ServiceCollection { get; set; }

        public WorkDataContext CreateDbContext(string[] args)
        {
            ServiceCollection = new ServiceCollection();

            #region ConfigurationBuilder

            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("Config/appsettings.json", optional: true, reloadOnChange: true);

            var config = builder.Build();

            #endregion ConfigurationBuilder

            ServiceCollection.Configure<WorkDataDbContextOptions>(config.GetSection("WorkDataDbContextOptions"));

            var workDataDbContextOptions = ServiceCollection.ResolveServiceValue<WorkDataDbContextOptions>();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<WorkDataContext>();

            var workDataDbConfig = workDataDbContextOptions.WorkDataDbConfigs
                .Single(x => x.KeyName == "BaseWorkData");

            switch (workDataDbConfig.WorkDataDbType)
            {
                case WorkDataDbType.SqlServer:
                    dbContextOptionsBuilder.UseSqlServer(workDataDbConfig.ConnectionString);
                    break;

                case WorkDataDbType.MySql:
                    throw new ArgumentOutOfRangeException();
                case WorkDataDbType.PgSql:
                    dbContextOptionsBuilder.UseNpgsql(workDataDbConfig.ConnectionString);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new WorkDataContext(dbContextOptionsBuilder.Options);
        }
    }
}