// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Web
// 文件名：Program.cs
// 创建标识：吴来伟 2018-05-28 11:19
// 创建描述：
//
// 修改标识：吴来伟2018-05-28 16:13
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WorkData.Dependency;
using WorkData.Domain.EntityFramework.EntityFramework.Contexts;
using WorkData.Domain.EntityFramework.Migrations;

#endregion

namespace WorkData.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/hosting.json", optional: true, reloadOnChange: true)
                .Build();
            var host = BuildWebHost(args, config);

            SeedData.Initialize(new WorkDataContext(IocManager.Instance.Resolve<DbContextOptions>()));

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args, IConfiguration configuration) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(configuration)
                .ConfigureServices(services => services.AddAutofac())
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();
    }
}