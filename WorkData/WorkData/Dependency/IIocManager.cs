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
using System;

#endregion

namespace WorkData.Dependency
{
    public interface IIocManager : IResolver, IRegistrar, IServiceCollectionResolve
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

        /// <summary>
        /// UpdateContainer
        /// </summary>
        /// <param name="containerBuilder"></param>
        [Obsolete("Containers should generally be considered immutable. Register all of your dependencies before building/resolving. If you need to change the contents of a container, you technically should rebuild the container. This method may be removed in a future major release.")]
        void UpdateContainer(ContainerBuilder containerBuilder);
    }
}