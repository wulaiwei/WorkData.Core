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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using WorkData.Code.JwtSecurityTokens;
using WorkData.EntityFramework;
using WorkData.Extensions.ServiceCollections;
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
            services.AddTransient<IPrincipal>(provider =>
            provider.GetService<IHttpContextAccessor>().HttpContext.User);
            
            var workDataBaseJwt = services.ResolveServiceValue<WorkDataBaseJwt>();
            #region WebUowFilter
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(WebUowFilter));
                options.Filters.Add(typeof(WorkDataExpectionFilter));
            });
            #endregion

            #region JWT
            services.AddAuthentication(options =>
                {
                    //认证middleware配置
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(o =>
                {
                    //主要是jwt  token参数设置
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        //Token颁发机构
                        ValidIssuer = workDataBaseJwt.Issuer,
                        //颁发给谁
                        ValidAudience = workDataBaseJwt.Audience,
                        //这里的key要进行加密，需要引用Microsoft.IdentityModel.Tokens
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(workDataBaseJwt.SecretKey)),
                        //ValidateIssuerSigningKey=true,
                        ////是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
                        ValidateLifetime = true,
                        ////允许的服务器时间偏移量
                        ClockSkew = TimeSpan.Zero
                    };
                });
            #endregion

            #region Autofac
            var paths = new List<string>
            {
                "Config/moduleConfig.json"
            };

            BootstrapWarpper.InitiateConfig(services, paths);
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