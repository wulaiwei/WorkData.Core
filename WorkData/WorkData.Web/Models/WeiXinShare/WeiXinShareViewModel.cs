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
        /// 分享者昵称
        /// </summary>
        [JsonProperty("shareOpenNick")]
        public string ShareOpenNick { get; set; }

        /// <summary>
        /// 点赞者OpenId
        /// </summary>
        [JsonProperty("likeOpenId")]
        public string LikeOpenId { get; set; }

        /// <summary>
        /// 点赞者昵称
        /// </summary>
        [JsonProperty("likeOpenNick")]
        public string LikeOpenNick { get; set; }
    }
}