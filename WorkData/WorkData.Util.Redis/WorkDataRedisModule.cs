// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Util.Redis
// 文件名：RedisModule.cs
// 创建标识：吴来伟 2018-03-21 14:22
// 创建描述：
//
// 修改标识：吴来伟2018-03-21 14:24
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using WorkData.Extensions.Modules;
using WorkData.Util.Common.Interceptors;
using WorkData.Util.Redis.Impl;
using WorkData.Util.Redis.Interface;
using WorkData.Util.Redis.RealTime;

#endregion

namespace WorkData.Util.Redis
{
    /// <summary>
    /// WorkDataRedisModule
    /// </summary>
    public class WorkDataRedisModule : WorkDataBaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(t => new WorkDataBaseInterceptor
                {
                    RetryCount=3
                })
                .Named<IInterceptor>
                ("WorkDataRedisInterceptor")
                .InstancePerLifetimeScope();

            builder.RegisterType<RedisService>().As<IRedisService>()
                .EnableInterfaceInterceptors(); 
            builder.RegisterType<BaseRedisServiceManager>();
        }
    }
}