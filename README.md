# Introduction
WorkData
    WorkData是一个轻量级，低级的框架，用于在.NET Framework/Core构建服务。框架的目标是提供项目常用的基础设施功能
    WorkData已经集成了Autofac，Ocelot网管，基于这些你可以做任意扩展。
开始工作：
1.完成IOC模块注入

        public static Bootstrap BootstrapWarpper { get; } = Bootstrap.Instance();
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var paths = new List<string>
            {
               "Config/commonConfig.json",
               "Config/moduleConfig.json"
            };

            BootstrapWarpper.InitiateConfig(services, paths);

            return new AutofacServiceProvider
                (BootstrapWarpper.IocManager.IocContainer);
        }
2.接入Ocelot网关

        WebHost.CreateDefaultBuilder(args)
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("Config/configuration.json",optional:true,reloadOnChange:true)
                        .AddEnvironmentVariables();
                })
                .ConfigureServices(services =>
                {
                    services.AddAutofac();
                    services.AddOcelot();
                })
                .UseStartup<Startup>()
                .UseIISIntegration()
                .Configure(app =>
                {
                    app.UseOcelot().Wait();
                })
                .UseUrls("http://+:8098")
                .Build();
3.配置文件详见项目
