// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData
// 文件名：IocManager.cs
// 创建标识：吴来伟 2017-11-22 17:38
// 创建描述：
//
// 修改标识：吴来伟2017-12-05 10:13
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Microsoft.Extensions.DependencyInjection;
using WorkData.Extensions.ServiceCollections;

#endregion

namespace WorkData.Dependency
{
    /// <summary>
    ///     IocManager
    /// </summary>
    public class IocManager : IIocManager
    {
        #region Instance

        /// <summary>
        ///     The Singleton instance.
        /// </summary>
        public static IocManager Instance { get; }

        /// <summary>
        ///     IocManager
        /// </summary>
        static IocManager()
        {
            Instance = new IocManager();
        }

        #endregion

        #region IContainer

        /// <summary>
        ///     IocContainer
        /// </summary>
        IContainer IIocManager.IocContainer
        {
            get => IocContainer;
            set => IocContainer = value;
        }

        /// <summary>
        ///     IocContainer
        /// </summary>
        public static IContainer IocContainer { get; set; }

        #endregion

        #region IServiceLocator

        IServiceLocator IIocManager.ServiceLocatorCurrent
        {
            get => ServiceLocatorCurrent;
            set => ServiceLocatorCurrent = value;
        }

        /// <summary>
        ///     ServiceLocator
        /// </summary>
        public static IServiceLocator ServiceLocatorCurrent { get; set; }

        #endregion

        #region IServiceCollection

        IServiceCollection IServiceCollectionResolve.ServiceCollection
        {
            get => ServiceCollection;
            set => ServiceCollection = value;
        }

        /// <summary>
        ///     ServiceCollection
        /// </summary>
        public static IServiceCollection ServiceCollection { get; set; }

        #endregion

        /// <summary>
        ///     SetContainer
        /// </summary>
        /// <param name="containerBuilder"></param>
        public void SetContainer(ContainerBuilder containerBuilder)
        {
            var container = containerBuilder.Build();
            IocContainer = container;

            //设置定位器
            ServiceLocatorCurrent = new AutofacServiceLocator(IocContainer);
        }

        #region serviceCollection

        /// <summary>
        /// SetServiceCollection
        /// </summary>
        /// <param name="serviceCollection"></param>
        public void SetServiceCollection(IServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection;
        }

        /// <summary>
        /// ResolveServiceValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ResolveServiceValue<T>() where T : class, new()
        {
            return ServiceCollection.ResolveServiceValue<T>();
        }

        /// <summary>
        /// ResolveServiceValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T ResolveServiceValue<T>(string key)
        {
            return ServiceCollection.ResolveConfig<T>(key);
        }

        /// <summary>
        /// ResolveServiceValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T ResolveEntityServiceValue<T>(string key) where T : class
        {
            return ServiceCollection.ResolveEntityConfig<T>(key);
        }

        #endregion
    }
}