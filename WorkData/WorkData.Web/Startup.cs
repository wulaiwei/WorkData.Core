// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Web
// 文件名：Startup.cs
// 创建标识：吴来伟 2018-05-28 11:19
// 创建描述：
//
// 修改标识：吴来伟2018-06-21 13:56
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using WorkData.Code.AutoMappers;
using WorkData.Code.JwtSecurityTokens;
using WorkData.Domain.EntityFramework.EntityFramework.Contexts;
using WorkData.EntityFramework;
using WorkData.EntityFramework.Extensions;
using WorkData.Extensions.TypeFinders;
using WorkData.Web.Extensions.Filters;
using WorkData.Web.Extensions.Infrastructure;

#endregion

namespace WorkData.Web
{
    public class Startup
    {
        /// <summary>
        ///     Gets a reference to the <see cref="Bootstrap" /> instance.
        /// </summary>
        public static Bootstrap BootstrapWarpper { get; } = Bootstrap.Instance();

        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("Config/appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"Config/appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        /// <summary>
        ///     ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<WorkDataBaseJwt>(Configuration.GetSection("WorkDataBaseJwt"));
            services.Configure<WorkDataDbConfig>(Configuration.GetSection("WorkDataDbContextConfig"));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);
            services.AddSingleton<ITypeFinder, WebAppTypeFinder>();

            #region AutoMapper
            services.AddWorkDataAutoMapper();
            #endregion

            #region WorkDataContext
            services.AddWorkDataDbContext<WorkDataContext>();
            #endregion

            #region WebUowFilter
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(WebUowFilter));
                options.Filters.Add(typeof(WorkDataExpectionFilter));
            });
            #endregion

            #region JWT
            services.AddWorkDataJwt();
            #endregion

            #region Autofac
            BootstrapWarpper.InitiateConfig(services, new List<string> { "Config/moduleConfig.json" });
            #endregion

            #region 初始化审计
            services.InitAuditable();
            #endregion

            return new AutofacServiceProvider
                (BootstrapWarpper.IocManager.IocContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //静态资源
            app.UseStaticFiles();
            //启用验证
            app.UseAuthentication();
            //Response
            app.UseResponse();
            //MVC
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}