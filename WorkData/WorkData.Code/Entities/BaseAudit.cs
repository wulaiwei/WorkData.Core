// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：BaseAudit.cs
// 创建标识：吴来伟 2017-12-19 11:16
// 创建描述：
//
// 修改标识：吴来伟2017-12-19 11:16
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkData.Code.Entities
{
    /// <summary>
    /// 基础审计配置
    /// </summary>
    [Serializable]
    public class BaseAudit : IAudit
    {
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
    }
}