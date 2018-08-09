// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Ocelot
// 文件名：Program.cs
// 创建标识：吴来伟 2018-06-01 16:55
// 创建描述：
//
// 修改标识：吴来伟2018-06-06 10:13
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.IO;

#endregion

namespace WorkData.Ocelot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config/hosting.json", optional: true, reloadOnChange: true)
                .Build();

            BuildWebHost(args, config).Run();
        }

        public static IWebHost BuildWebHost(string[] args, IConfiguration configuration) =>
            WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
               .UseConfiguration(configuration)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("Config/configuration.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables();
                })
                .ConfigureServices(services =>
                {
                    services.AddAutofac();
                    services.AddOcelot();
                })
                .UseStartup<Startup>()
                .UseIISIntegration()
                .Configure(app => { app.UseOcelot().Wait(); })
                //.UseUrls("http://+:8011")
                .Build();
    }
}