// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：BaseUserIdentity.cs
// 创建标识：吴来伟 2017-12-19 11:11
// 创建描述：
//
// 修改标识：吴来伟2017-12-19 11:30
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using WorkData.Code.Entities;

#endregion

namespace WorkData.Code.WorkDataIdentity
{
    /// <summary>
    ///     基础用户表（如无需使用可直接继承IIdentity进行扩展）
    /// </summary>
    public abstract class BaseUserIdentity<TPrimaryKey> : BaseEntity
        , IIdentityUser<TPrimaryKey> where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        /// <summary>
        ///     Id
        /// </summary>
        public virtual TPrimaryKey Id { get; set; }

        /// <summary>
        ///     用户名
        /// </summary>
        public virtual string UserName { get; set; }
    }
}