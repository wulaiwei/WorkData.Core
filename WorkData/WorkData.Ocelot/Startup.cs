// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Ocelot
// 文件名：Startup.cs
// 创建标识：吴来伟 2018-06-01 16:55
// 创建描述：
//
// 修改标识：吴来伟2018-06-01 16:58
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

#endregion

namespace WorkData.Ocelot
{
    public class Startup
    {
        /// <summary>
        ///     Gets a reference to the <see cref="Bootstrap" /> instance.
        /// </summary>
        public static Bootstrap BootstrapWarpper { get; } = Bootstrap.Instance();

        /// <summary>
        ///     ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var paths = new List<string>
            {
               "Config/commonConfig.json",
               "Config/moduleConfig.json"
            };

            BootstrapWarpper.InitiateConfig(paths,services);

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
        }
    }
}