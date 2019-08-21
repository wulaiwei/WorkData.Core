// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData
// 文件名：Bootstrap.cs
// 创建标识：吴来伟 2017-12-06 18:17
// 创建描述：
//
// 修改标识：吴来伟2017-12-18 16:43
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using WorkData.Dependency;

#endregion

namespace WorkData
{
    /// <summary>
    ///     初始化装载程序
    /// </summary>
    public class Bootstrap
    {
        /// <summary>
        ///     _isInit
        /// </summary>
        private static bool _isInit;

        /// <summary>
        ///     _iocManager
        /// </summary>
        public IIocManager IocManager { get; set; }

        #region Instance

        /// <summary>
        ///     instance bootstrap
        /// </summary>
        /// <returns></returns>
        public static Bootstrap Instance()
        {
            return new Bootstrap();
        }

        /// <summary>
        ///     Bootstrap
        /// </summary>
        public Bootstrap() : this(Dependency.IocManager.Instance)
        {
        }

        /// <summary>
        ///     Bootstrap
        /// </summary>
        /// <param name="iocManager"></param>
        public Bootstrap(IIocManager iocManager)
        {
            IocManager = iocManager;
        }

        #endregion

        #region 初始化集成框架(Core)

        /// <summary>
        ///  初始化集成框架(Core)
        /// </summary>
        [STAThread]
        public void InitiateConfig(List<string> paths, IServiceCollection services)
        {
            if (_isInit) return;
            var builder = new ContainerBuilder();
            if (services != null)
            {
                //初始化IServiceCollection
                IocManager.SetServiceCollection(services);
                builder.Populate(services);
            }

            #region RegisterConfig
            var config = new ConfigurationBuilder();
            config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
            if (paths != null)
            {
                foreach (var item in paths)
                {
                    config.AddJsonFile(item);
                }
            }
            var module = new ConfigurationModule(config.Build());
            builder.RegisterModule(module);
            #endregion

            //注入初始module
            builder.RegisterModule(new WorkDataModule());
            IocManager.SetContainer(builder);
            _isInit = true;
        }

        #endregion
    }
}