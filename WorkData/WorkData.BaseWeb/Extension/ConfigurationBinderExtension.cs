using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace WorkData.BaseWeb.Extension
{
    public static class ConfigurationBinderExtension
    {
        public static T GetWorkDataValue<T>(this IConfiguration configuration, string key)
        {
            var data = configuration.GetValue<string>("version");
            return JsonConvert.DeserializeObject<T>(data);
        }


    }
}
