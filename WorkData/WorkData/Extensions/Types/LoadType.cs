// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData
// 文件名：LoadType.cs
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
    ///     LoadType
    /// </summary>
    public class LoadType : ILoadType
    {
        private readonly ILoadAssembly _loadAssembly;
        private readonly object _syncObj = new object();
        private Type[] _types;

        public LoadType()
        {
            _loadAssembly = NullLoadAssembly.Instance;
        }

        /// <summary>
        ///     get all types
        /// </summary>
        /// <returns></returns>
        public Type[] GetAll()
        {
            var types = GetAllTypes();
            return types.ToArray();
        }

        /// <summary>
        ///     get all types
        /// </summary>
        /// <returns></returns>
        public Type[] GetAll(Func<Type, bool> predicate)
        {
            var types = GetAllTypes();
            var s = types.Where(x => x.Name.Contains("QueueSchedulingService")).ToArray();
            return types.Where(predicate).ToArray();
        }

        /// <summary>
        ///     GetAllTypes
        /// </summary>
        /// <returns></returns>
        private Type[] GetAllTypes()
        {
            if (_types != null) return _types;
            lock (_syncObj)
            {
                if (_types == null)
                {
                    // ReSharper disable once PossibleMultipleWriteAccessInDoubleCheckLocking
                    _types = GetTypeList().ToArray();
                }
            }

            return _types;
        }

        /// <summary>
        ///     GetTypeList
        /// </summary>
        /// <returns></returns>
        private List<Type> GetTypeList()
        {
            var allTypes = new List<Type>();

            var assemblies = _loadAssembly.GetAllAssembly().Distinct();

            foreach (var assembly in assemblies)
            {
                Type[] typesInThisAssembly;

                try
                {
                    typesInThisAssembly = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException ex)
                {
                    typesInThisAssembly = ex.Types;
                }

                if (typesInThisAssembly == null)
                {
                    continue;
                }

                allTypes.AddRange(typesInThisAssembly.Where(type => type != null));
            }

            return allTypes;
        }
    }
}