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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Senparc.CO2NET;
using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin;
using Senparc.Weixin.Entities;
using Senparc.Weixin.RegisterServices;
using WorkData.Code.AutoMappers;
using WorkData.Code.Entities;
using WorkData.Code.JwtSecurityTokens;
using WorkData.Code.Sessions;
using WorkData.Code.Webs.Extension;
using WorkData.Code.Webs.Filters;
using WorkData.Code.Webs.WorkDataMiddlewares;
using WorkData.Dependency;
using WorkData.Domain.EntityFramework.EntityFramework.Contexts;
using WorkData.Domain.EntityFramework.EntityFramework.Filters;
using WorkData.EntityFramework;
using WorkData.EntityFramework.Extensions;
using WorkData.EntityFramework.Repositories.Filters.Configs;
using WorkData.Extensions.ServiceCollections;
using WorkData.Extensions.TypeFinders;
using WorkData.WeiXin.Config;
using Z.EntityFramework.Plus;

#endregion

namespace WorkData.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("Config/appsettings.json", true, true)
                .AddJsonFile($"Config/appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <summary>
        ///     Gets a reference to the <see cref="Bootstrap" /> instance.
        /// </summary>
        public static Bootstrap BootstrapWarpper { get; } = Bootstrap.Instance();

        public IConfigurationRoot Configuration { get; }

        /// <summary>
        ///     ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<WorkDataBaseJwt>(Configuration.GetSection("WorkDataBaseJwt"));
            services.Configure<WorkDataDbContextOptions>(Configuration.GetSection("WorkDataDbContextOptions"));
            services.Configure<WechatAppSettings>(Configuration.GetSection("WechatAppSettings"));
            services.Configure<DynamicFilterConfig>(Configuration.GetSection("DynamicFilterConfig"));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPrincipal>(provider =>
                provider.GetService<IHttpContextAccessor>().HttpContext?.User);
            //services.AddSingleton<ITypeFinder, WebAppTypeFinder>();
  

            #region AutoMapper

            services.AddWorkDataAutoMapper();

            #endregion

            #region WorkDataContext

            services.AddWorkDataDbContext<WorkDataContext>("BaseWorkData");

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

            BootstrapWarpper.InitiateConfig(new List<string> { "Config/moduleConfig.json" },services);

            #endregion

            #region 初始化审计

            services.InitAuditable();

            #endregion

            services.AddMemoryCache();//使用本地缓存必须添加
            services.AddSession();//使用Session

            services.AddSenparcGlobalServices(Configuration)//Senparc.CO2NET 全局注册
                .AddSenparcWeixinServices(Configuration);//Senparc.Weixin 注册


            return new AutofacServiceProvider
                (BootstrapWarpper.IocManager.IocContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptions<SenparcSetting> senparcSetting, IOptions<SenparcWeixinSetting> senparcWeixinSetting)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            var register = RegisterService.Start(env, senparcSetting.Value).UseSenparcGlobal();// 启动 CO2NET 全局注册，必须！

            register.UseSenparcWeixin(senparcWeixinSetting.Value, senparcSetting.Value);//微信全局注册，必须！

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
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}