// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：BaseRoleIdentity.cs
// 创建标识：吴来伟 2017-12-19 13:39
// 创建描述：
//
// 修改标识：吴来伟2017-12-19 13:39
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorkData.Code.Entities;

namespace WorkData.Code.WorkDataIdentity
{
    /// <summary>
    ///  基础角色表（如无需使用可直接继承IIdentity进行扩展）
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class BaseRoleIdentity<TPrimaryKey> : BaseEntity
        , IIdentityRole<TPrimaryKey> where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        /// <summary>
        /// Id
        /// </summary>
        [Column("Id")]
        public virtual TPrimaryKey Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [StringLength(150)]
        [Column("RoleName")]
        public virtual string RoleName { get; set; }
    }
}