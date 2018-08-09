// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData
// 文件名：ReflectionHelper.cs
// 创建标识：吴来伟 2017-12-14 10:41
// 创建描述：
//
// 修改标识：吴来伟2017-12-14 10:42
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#endregion

namespace WorkData.Code.Helpers
{
    public class ReflectionHelper
    {
        /// <summary>
        ///     Checks whether <paramref name="givenType" /> implements/inherits <paramref name="genericType" />.
        /// </summary>
        /// <param name="givenType">Type to check</param>
        /// <param name="genericType">Generic type</param>
        public static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            var givenTypeInfo = givenType.GetTypeInfo();

            if (givenTypeInfo.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
            {
                return true;
            }

            if (givenType.GetInterfaces().Any(interfaceType => interfaceType.GetTypeInfo().IsGenericType &&
                                                               interfaceType.GetGenericTypeDefinition() == genericType))
            {
                return true;
            }

            return givenTypeInfo.BaseType != null && IsAssignableToGenericType(givenTypeInfo.BaseType, genericType);
        }


        /// <summary>
        ///     Checks whether <paramref name="givenType" /> implements/inherits <paramref name="type" />.
        /// </summary>
        /// <param name="givenType">Type to check</param>
        /// <param name="type">type</param>
        public static bool IsAssignableToType(Type givenType, Type type)
        {
            var givenTypeInfo = givenType.GetTypeInfo();

            if (givenType.GetInterfaces().Any(interfaceType =>interfaceType == type))
            {
                return true;
            }

            return givenTypeInfo.BaseType != null && IsAssignableToType(givenTypeInfo.BaseType, type);
        }

    }
}