using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Com.Ctrip.Framework.Apollo;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WorkData.Code.JwtSecurityTokens;

namespace WorkData.ApolloWeb
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static Bootstrap BootstrapWarpper { get; } = Bootstrap.Instance();

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<WorkDataBaseJwt>(Configuration.GetSection("WorkDataBaseJwt"));
            services.AddMvc();
            #region Autofac
            BootstrapWarpper.InitiateConfig(new List<string> { "Config/moduleConfig.json" }, services);
            #endregion
            return new AutofacServiceProvider
                (BootstrapWarpper.IocManager.IocContainer);
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            //静态资源
            app.UseStaticFiles();
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
