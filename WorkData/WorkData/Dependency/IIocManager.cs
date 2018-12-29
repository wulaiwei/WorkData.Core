// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData
// 文件名：IIocManager.cs
// 创建标识：吴来伟 2017-11-22 17:31
// 创建描述：
//
// 修改标识：吴来伟2017-11-29 10:25
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Autofac;
using CommonServiceLocator;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace WorkData.Dependency
{
    public interface IIocManager : IServiceCollectionResolve
    {
        /// <summary>
        ///     Reference to the Autofac Container.
        /// </summary>
        IContainer IocContainer { get; set; }

        /// <summary>
        ///     ServiceLocatorCurrent
        /// </summary>
        IServiceLocator ServiceLocatorCurrent { get; set; }

        /// <summary>
        ///     SetContainer
        /// </summary>
        /// <param name="containerBuilder"></param>
        void SetContainer(ContainerBuilder containerBuilder);

        /// <summary>
        /// SetServiceCollection
        /// </summary>
        /// <param name="serviceCollection"></param>
        void SetServiceCollection(IServiceCollection serviceCollection);
    }
}