// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData
// 文件名：WorkDataBaseModules.cs
// 创建标识：吴来伟 2017-12-11 16:20
// 创建描述：
//
// 修改标识：吴来伟2017-12-11 16:20
// 修改描述：
//  ------------------------------------------------------------------------------

using Autofac;
using WorkData.Dependency;

namespace WorkData.Extensions.Modules
{
    public abstract class WorkDataBaseModule : Module
    {
        /// <summary>
        /// Gets a reference to the IOC manager.
        /// </summary>
        public IIocManager IocManager { get; set; }
    }
}