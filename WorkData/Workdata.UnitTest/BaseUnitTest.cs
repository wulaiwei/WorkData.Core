// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Workdata.UnitTest
// 文件名：BaseUnitTest.cs
// 创建标识：吴来伟 2018-07-25 17:57
// 创建描述：
//  
// 修改标识：吴来伟2018-07-25 22:37
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkData;
using WorkData.Code.JwtSecurityTokens;
using WorkData.Dependency;
using WorkData.Domain.EntityFramework.EntityFramework.Sessions;
using WorkData.EntityFramework;

#endregion

namespace Workdata.UnitTest
{
    public class BaseUnitTest
    {
        /// <summary>
        ///     Gets a reference to the <see cref="Bootstrap" /> instance.
        /// </summary>
        public static Bootstrap BootstrapWarpper { get; } =
            Bootstrap.Instance();
        /// <summary>
        /// WorkDataSession
        /// </summary>s
        public IWorkDataSessionExtension WorkDataSession { get; set; }

        /// <summary>
        ///     Configuration
        /// </summary>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        ///     ServiceCollection
        /// </summary>
        public IServiceCollection ServiceCollection { get; set; }

        public BaseUnitTest()
        {
            ServiceCollection = new ServiceCollection();

            #region ConfigurationBuilder

            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("Config/appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            #endregion

            ServiceCollection.Configure<WorkDataBaseJwt>(Configuration.GetSection("WorkDataBaseJwt"));
            ServiceCollection.Configure<WorkDataDbConfig>(Configuration.GetSection("WorkDataDbContextConfig"));

            #region Autofac

            var paths = new List<string>
            {
                "Config/moduleConfig.json"
            };

            BootstrapWarpper.InitiateConfig(ServiceCollection, paths);
            #endregion
        }
    }
}