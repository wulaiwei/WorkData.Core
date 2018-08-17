using Newtonsoft.Json;

namespace WorkData.WeiXin.WeiXin.Model
{
    public class ResponseMessage
    {
        /*
        {
   "errcode": 0,
   "errmsg": "ok",
   "invaliduser": "UserID1",
   "invalidparty":"PartyID1",
   "invalidtag":"TagID1"
}
            */

        /// <summary>
        /// 返回码
        /// </summary>
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        /// <summary>
        ///错误消息
        /// </summary>
        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        /// <summary>
        /// 无效用户列表
        /// </summary>
        [JsonProperty("invaliduser")]
        public string InvalidUser { get; set; }

        /// <summary>
        /// 无效部门列表
        /// </summary>
        [JsonProperty("invalidparty")]
        public string InvalidParty { get; set; }

        /// <summary>
        /// 无效标签列表
        /// </summary>
        [JsonProperty("invalidtag")]
        public string InvalidTag { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}