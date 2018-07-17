// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：BaseGroup.cs
// 创建标识：吴来伟 2017-12-19 11:23
// 创建描述：
//
// 修改标识：吴来伟2017-12-19 11:23
// 修改描述：
//  ------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkData.Code.Entities
{
    /// <summary>
    /// 基础用户组
    /// </summary>
    public class BaseGroup : IGroup
    {
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
    }
}