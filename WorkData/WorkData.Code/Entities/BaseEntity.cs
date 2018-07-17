// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：BaseEntity.cs
// 创建标识：吴来伟 2017-12-19 11:26
// 创建描述：
//
// 修改标识：吴来伟2017-12-19 11:26
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkData.Code.Entities
{
    /// <summary>
    /// 基础实体
    /// </summary>
    [Serializable]
    public abstract class BaseEntity : IAudit, IGroup, ISoftDelete
    {
        #region 审计

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("CreateTime")]
        [Required]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [StringLength(500)]
        [Column("CreateUserId")]
        public virtual string CreateUserId { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        [Column("ModifierTime")]
        public virtual DateTime? ModifierTime { get; set; }

        /// <summary>
        /// 编辑用户
        /// </summary>
        [StringLength(500)]
        [Column("ModifierUserId")]
        public virtual string ModifierUserId { get; set; }

        #endregion 审计

        #region 用户组

        /// <summary>
        /// 所属用户
        /// </summary>
        [StringLength(500)]
        [Column("BelongUserId")]
        public virtual string BelongUserId { get; set; }

        /// <summary>
        /// 所属Member
        /// </summary>
        [StringLength(500)]
        [Column("MemberUserId")]
        public virtual string MemberUserId { get; set; }

        #endregion 用户组

        #region 软删除

        /// <summary>
        /// 是否删除
        /// </summary>
        public virtual bool IsDelete { get; set; }

        #endregion 软删除
    }
}