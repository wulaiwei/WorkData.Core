using System.Collections.Generic;
using Newtonsoft.Json;

namespace WorkData.WeiXin.WeiXin.Model
{
    /// <summary>
    /// 微信内容
    /// </summary>
    public class WeiXinArticle
    {
        /// <summary>
        /// 标题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = "";

        /// <summary>
        /// 点击后跳转的链接。
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; } = "";

        /// <summary>
        /// 图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图640*320，小图80*80。如不填，在客户端不显示图片
        /// </summary>
        [JsonProperty("picurl")]
        public string Picurl { get; set; } = "";

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    ///新闻集合
    /// </summary>
    public class NewsCollect
    {
        /// <summary>
        ///必填项 图文消息，一个图文消息支持1到10条图文
        /// </summary>
        [JsonProperty("articles")]
        public List<WeiXinArticle> Articles { get; set; } = new List<WeiXinArticle>(10);

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    /// <summary>
    /// 新闻消息
    /// </summary>
    public class NewsMessage
    {
        /*
           {
           "touser": "UserID1|UserID2|UserID3",
           "toparty": " PartyID1 | PartyID2 ",
           "totag": " TagID1 | TagID2 ",
           "msgtype": "news",
           "agentid": "1",
           "news": {
               "articles":[
                   {
                       "title": "Title",
                       "description": "Description",
                       "url": "URL",
                       "picurl": "PIC_URL"
                   },
                   {
                       "title": "Title",
                       "description": "Description",
                       "url": "URL",
                       "picurl": "PIC_URL"
                   }
               ]
           }
        }
        */

        /// <summary>
        /// 成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。特殊情况：指定为@all，则向关注该企业应用的全部成员发送
        /// </summary>
        [JsonProperty("touser")]
        public string ToUser { get; set; }

        /// <summary>
        /// 部门ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数
        /// </summary>
        [JsonProperty("toparty")]
        public string ToParty { get; set; }

        /// <summary>
        /// 标签ID列表，多个接收者用‘|’分隔。当touser为@all时忽略本参数
        /// </summary>
        [JsonProperty("totag")]
        public string ToTag { get; set; }

        /// <summary>
        ///必填项 消息类型，此时固定为：news
        /// </summary>
        [JsonProperty("msgtype")]
        public string MsgType { get; } = "news";

        /// <summary>
        ///必填项 企业应用的id，整型。可在应用的设置页面查看
        /// </summary>
        [JsonProperty("agentid")]
        public string AgentId { get; set; }

        /// <summary>
        /// 消息体
        /// </summary>
        [JsonProperty("news")]
        public NewsCollect News { get; set; } = new NewsCollect();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}