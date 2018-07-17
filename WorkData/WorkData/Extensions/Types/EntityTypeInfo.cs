// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.EntityFramework
// 文件名：EntityTypeInfo.cs
// 创建标识：吴来伟 2017-12-14 10:25
// 创建描述：
//
// 修改标识：吴来伟2017-12-14 10:25
// 修改描述：
//  ------------------------------------------------------------------------------

using System;

namespace WorkData.Extensions.Types
{
    public class EntityTypeInfo
    {
        /// <summary>
        /// Type of the entity.
        /// </summary>
        public Type EntityType { get; private set; }

        /// <summary>
        /// DbContext type that has DbSet property.
        /// </summary>
        public Type DeclaringType { get; private set; }

        public EntityTypeInfo(Type entityType, Type declaringType)
        {
            EntityType = entityType;
            DeclaringType = declaringType;
        }
    }
}