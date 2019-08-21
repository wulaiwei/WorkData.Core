// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData
// 文件名：WorkDataServiceCollection.cs
// 创建标识：吴来伟 2018-06-22 9:28
// 创建描述：
//
// 修改标识：吴来伟2018-06-22 9:28
// 修改描述：
//  ------------------------------------------------------------------------------

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;

namespace WorkData.Extensions.ServiceCollections
{
    public static class WorkDataServiceCollection
    {
        public static T ResolveServiceValue<T>(this IServiceCollection services) where T : class, new()
        {
            try
            {
                var provider = services.BuildServiceProvider();
                var entity = provider.GetRequiredService<IOptions<T>>().Value;
                return entity;
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public static T ResolveEntityConfig<T>(this IServiceCollection services, string key) where T : class
        {
            var provider = services.BuildServiceProvider();
            var configuration = provider.GetService<IConfiguration>();
            if (configuration == null)
                throw new NullReferenceException("IConfiguration is null");

            try
            {
                var data = configuration.GetValue<string>(key);
                return JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public static T ResolveConfig<T>(this IServiceCollection services, string key)
        {
            var provider = services.BuildServiceProvider();
            var configuration = provider.GetService<IConfiguration>();
            if (configuration == null)
                throw new NullReferenceException("IConfiguration is null");

            try
            {
                return configuration.GetValue<T>(key);
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}