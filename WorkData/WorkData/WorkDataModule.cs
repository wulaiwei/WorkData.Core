// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData
// 文件名：WorkDataModule.cs
// 创建标识：吴来伟 2017-12-12 9:27
// 创建描述：
//
// 修改标识：吴来伟2017-12-12 9:28
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Autofac;
using WorkData.Dependency;
using WorkData.Extensions.Types;

#endregion

namespace WorkData
{
    public class WorkDataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IocManager>()
                .As<IIocManager, IResolver, IRegistrar>();

            builder.RegisterType<LoadAssembly>()
                .As<ILoadAssembly>().PropertiesAutowired();

            builder.RegisterType<LoadType>()
                .As<ILoadType>().PropertiesAutowired();
        }
    }
}