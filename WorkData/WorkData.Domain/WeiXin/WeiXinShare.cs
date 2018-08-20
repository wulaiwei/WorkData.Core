using System;
using System.ComponentModel.DataAnnotations.Schema;
using WorkData.Code.Entities;
using WorkData.Code.Entities.BaseInterfaces;
using WorkData.Code.Repositories;

namespace WorkData.Domain.WeiXin
{
    /// <summary>
    /// 微信分享逻辑
    /// </summary>
    public class WeiXinShare: ICreate, IAggregateRoot, IEntity<string>
    {
        /// <summary>
        /// Id
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 分享者OpenId
        /// </summary>
        public virtual string ShareOpenId { get; set; }

        /// <summary>
        /// 分享者昵称
        /// </summary>
        public virtual string ShareOpenNick { get; set; }

        /// <summary>
        /// 点赞者OpenId
        /// </summary>
        public virtual string LikeOpenId { get; set; }

        /// <summary>
        /// 点赞者昵称
        /// </summary>
        public virtual string LikeOpenNick { get; set; }

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