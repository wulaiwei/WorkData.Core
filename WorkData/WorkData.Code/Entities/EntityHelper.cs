// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData
// 文件名：EntityHelper.cs
// 创建标识：吴来伟 2017-12-14 10:41
// 创建描述：
//
// 修改标识：吴来伟2017-12-14 10:45
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.Reflection;
using WorkData.Util.Common.Helpers;

#endregion

namespace WorkData.Code.Entities
{
    public class EntityHelper
    {
        public static bool IsEntity(Type type)
        {
            return ReflectionHelper.IsAssignableToGenericType(type, typeof(IEntity<>));
        }

        public static Type GetPrimaryKeyType<TEntity>()
        {
            return GetPrimaryKeyType(typeof(TEntity));
        }

        /// <summary>
        ///     Gets primary key type of given entity type
        /// </summary>
        public static Type GetPrimaryKeyType(Type entityType)
        {
            foreach (var interfaceType in entityType.GetTypeInfo().GetInterfaces())
            {
                if (interfaceType.GetTypeInfo().IsGenericType &&
                    interfaceType.GetGenericTypeDefinition() == typeof(IEntity<>))
                {
                    return interfaceType.GenericTypeArguments[0];
                }
            }
            throw new Exception("Exception");
        }
    }
}