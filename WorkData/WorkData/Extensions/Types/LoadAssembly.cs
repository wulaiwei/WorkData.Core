// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData
// 文件名：LoadAssembly.cs
// 创建标识：吴来伟 2017-12-12 9:18
// 创建描述：
//
// 修改标识：吴来伟2017-12-12 9:19
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#endregion

namespace WorkData.Extensions.Types
{
    /// <summary>
    ///     LoadAssembly
    /// </summary>
    public class LoadAssembly : ILoadAssembly
    {
        public List<Assembly> GetAllAssembly()
        {
            return AppDomain.CurrentDomain.GetAssemblies().ToList();
        }
    }
}