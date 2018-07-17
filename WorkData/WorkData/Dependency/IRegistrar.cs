// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData
// 文件名：IRegistrar.cs
// 创建标识：吴来伟 2017-11-24 18:00
// 创建描述：
//
// 修改标识：吴来伟2017-11-24 18:00
// 修改描述：
//  ------------------------------------------------------------------------------

using Autofac;

namespace WorkData.Dependency
{
    public interface IRegistrar
    {
        /// <summary>
        /// Reference to the Autofac Container.
        /// </summary>
        ContainerBuilder ContainerBuilder { get; set; }
    }
}