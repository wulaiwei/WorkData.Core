using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WorkData.Code.Entities;
using WorkData.Code.Entities.BaseInterfaces;
using WorkData.Code.Repositories;

namespace WorkData.Domain.WeiXin
{
    /// <summary>
    /// 微信 用户信息
    /// </summary>
    public class WeiXinUserInfo : ICreate, IAggregateRoot, IEntity<string>
    {
        public string Id { get; set; }

        /// <summary>
        /// OpenId
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// NickName
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// Province
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// HeadImgUrl
        /// </summary>
        public string HeadImgUrl { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// UnionId
        /// </summary>
        public string UnionId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("CreateTime", Order = 99, TypeName = "timestamp(0)")]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建者Id
        /// </summary>

        public virtual string CreateUserId { get; set; }

    }
}
