// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Infrastructure
// 文件名：ILadAssembly.cs
// 创建标识：吴来伟 2017-12-11 14:42
// 创建描述：
//
// 修改标识：吴来伟2017-12-11 14:42
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Reflection;

namespace WorkData.Extensions.Types
{
    /// <summary>
    /// ILoadAssembly
    /// </summary>
    public interface ILoadAssembly
    {
        /// <summary>
        /// GetAllAssembly
        /// </summary>
        /// <returns></returns>
        List<Assembly> GetAllAssembly();
    }
}