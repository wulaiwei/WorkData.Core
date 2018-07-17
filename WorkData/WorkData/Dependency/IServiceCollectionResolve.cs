// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData
// 文件名：IServiceCollectionResolve.cs
// 创建标识：吴来伟 2018-06-22 9:47
// 创建描述：
//
// 修改标识：吴来伟2018-06-22 9:47
// 修改描述：
//  ------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;

namespace WorkData.Dependency
{
    public interface IServiceCollectionResolve
    {
        IServiceCollection ServiceCollection { get; set; }

        T ResolveServiceValue<T>() where T : class, new();
    }
}