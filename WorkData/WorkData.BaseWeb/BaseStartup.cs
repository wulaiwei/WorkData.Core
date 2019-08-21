using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace WorkData.BaseWeb
{
    public class BaseStartup
    {
        public static Bootstrap BootstrapWarpper { get; } = Bootstrap.Instance();

        public IConfiguration Configuration { get; set; }

        public BaseStartup(IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}