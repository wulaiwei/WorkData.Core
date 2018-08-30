using Microsoft.CodeAnalysis.Operations;
using Newtonsoft.Json;

namespace WorkData.Web.Models.WeiXinShare
{
    public class WeiXinShareViewModel
    {
        /// <summary>
        /// 分享者OpenId
        /// </summary>
        [JsonProperty("shareOpenId")]
        public string ShareOpenId { get; set; }

        /// <summary>
        /// 点赞者OpenId
        /// </summary>
        [JsonProperty("likeOpenId")]
        public string LikeOpenId { get; set; }
    }

    public enum ShareEnum
    {
        默认 = 0,
        分享点赞 = 1,
        分享无法点赞=2,
        非法=5
    }

    /// <summary>
    /// WeiXinShareLikeViewModel
    /// </summary>
    public class WeiXinShareLikeViewModel
    {
        public string OpenId { get; set; }

        public string ShareId { get; set; }

        public string Url { get; set; } 
    }
}