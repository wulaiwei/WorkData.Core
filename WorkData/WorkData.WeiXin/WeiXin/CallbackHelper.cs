using System;
using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;

namespace WorkData.WeiXin.WeiXin
{
    public class CallbackHelper
    {
        /// <summary>
        /// 构建消息主体
        /// </summary>
        /// <param name="msgtype"></param>
        /// <param name="agentid"></param>
        /// <param name="safe"></param>
        /// <param name="toUser"></param>
        /// <returns></returns>
        public static dynamic CreateDataMessage(string msgtype, int agentid, int safe, List<string> toUser)
        {
            dynamic tradeData = new ExpandoObject();
            tradeData.touser = string.Join("|", toUser.ToArray());
            tradeData.toparty = "";
            tradeData.totag = "";
            tradeData.msgtype = msgtype == "shortvideo" ? "video" : msgtype;
            tradeData.agentid = 9;
            tradeData.safe = 0;
            return tradeData;
        }


        /// <summary>
        /// 文本消息
        /// </summary>
        /// <param name="content"></param>
        /// <param name="tradeData"></param>
        /// <returns></returns>
        public static string CreateTextJsonMessage(string content, dynamic tradeData)
        {
            dynamic text = new ExpandoObject();
            text.content = content;
            tradeData.text = text;
            return JsonConvert.SerializeObject(tradeData);
        }

        /// <summary>
        /// 图片消息消息
        /// </summary>
        /// <param name="imgMediaId"></param>
        /// <param name="tradeData"></param>
        /// <returns></returns>
        public static string CreateImageJsonMessage(string imgMediaId, dynamic tradeData)
        {
            dynamic image = new ExpandoObject();
            image.media_id = imgMediaId;
            tradeData.image = image;
            return JsonConvert.SerializeObject(tradeData);
        }

        /// <summary>
        /// 音频消息
        /// </summary>
        /// <param name="voiceMediaId"></param>
        /// <param name="tradeData"></param>
        /// <returns></returns>
        public static string CreateVoiceJsonMessage(string voiceMediaId, dynamic tradeData)
        {
            dynamic voice = new ExpandoObject();
            voice.media_id = voiceMediaId;
            tradeData.voice = voice;
            return JsonConvert.SerializeObject(tradeData);
        }

        /// <summary>
        /// 短视频消息
        /// </summary>
        /// <param name="videoMediaId"></param>
        /// <param name="tradeData"></param>
        /// <returns></returns>
        public static string CreateShortVideoJsonMessage(string videoMediaId, dynamic tradeData)
        {
            dynamic shortVideo = new ExpandoObject();
            shortVideo.media_id = videoMediaId;
            tradeData.shortvideo = shortVideo;
            return JsonConvert.SerializeObject(tradeData);
        }

        /// <summary>
        /// 视频消息
        /// </summary>
        /// <param name="videoMediaId"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="tradeData"></param>
        /// <returns></returns>
        public static string CreateVideoJsonMessage(string videoMediaId, string title, string description, dynamic tradeData)
        {
            dynamic video = new ExpandoObject();
            video.media_id = videoMediaId;
            video.title = title;
            video.description = description;
            tradeData.video = video;
            return JsonConvert.SerializeObject(tradeData);
        }

        /// <summary>
        /// 视频消息
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="url"></param>
        /// <param name="tradeData"></param>
        /// <param name="picUrl"></param>
        /// <returns></returns>
        public static string CreateNewsJsonMessage(string title, string description, string picUrl, string url, dynamic tradeData)
        {
            dynamic news = new ExpandoObject();

            var articles = new List<Article>()
            {
                new Article
                {
                    description =description,
                    title=title,
                    picurl=picUrl,
                    url=url
                }
            };
            news.articles = articles;
            tradeData.news = news;

            return JsonConvert.SerializeObject(tradeData);
        }

        public class Article
        {
            public string title { get; set; }
            public string description { get; set; }
            public string url { get; set; }
            public string picurl { get; set; }
        }

        #region 回调XML （被动模式）
        public static string CreateTextMessage(string corpId, List<string> toUser, string content)
        {
            var message = $@"
<xml>
   <ToUserName><![CDATA[{string.Join(",", toUser.ToArray())}]]></ToUserName>
   <FromUserName><![CDATA[{corpId}]]></FromUserName>
   <CreateTime>{DateTime.Now.Ticks}</CreateTime>
   <MsgType><![CDATA[text]]></MsgType>
   <Content><![CDATA[{content}]]></Content>
</xml>
";
            return message;
        }

        public static string CreateImageMessage(string corpId, List<string> toUser, string mediaId)
        {
            var message = $@"
<xml>
   <ToUserName><![CDATA[{string.Join(",", toUser.ToArray())}]]></ToUserName>
   <FromUserName><![CDATA[{corpId}]]></FromUserName>
   <CreateTime>{DateTime.Now.Ticks}</CreateTime>
   <MsgType><![CDATA[image]]></MsgType>
   <Image>
       <MediaId><![CDATA[{mediaId}]]></MediaId>
   </Image>
</xml>
";
            return message;
        }

        public static string CreateVoiceMessage(string corpId, List<string> toUser, string mediaId)
        {
            var message = $@"
<xml>
   <ToUserName><![CDATA[{string.Join(",", toUser.ToArray())}]]></ToUserName>
   <FromUserName><![CDATA[{corpId}]]></FromUserName>
   <CreateTime>{DateTime.Now.Ticks}</CreateTime>
   <MsgType><![CDATA[voice]]></MsgType>
   <Voice>
       <MediaId><![CDATA[{mediaId}]]></MediaId>
   </Voice>
</xml>
";
            return message;
        }

        public static string CreateVideoMessage(string corpId, List<string> toUser, string mediaId)
        {
            var message = $@"
<xml>
   <ToUserName><![CDATA[{string.Join(",", toUser.ToArray())}]]></ToUserName>
   <FromUserName><![CDATA[{corpId}]]></FromUserName>
   <CreateTime>{DateTime.Now.Ticks}</CreateTime>
   <MsgType><![CDATA[image]]></MsgType>
    <Video>
       <MediaId><![CDATA[{mediaId}]]></MediaId>
       <Title><![CDATA[]]></Title>
       <Description><![CDATA[]]></Description>
   </Video>
</xml>
";
            return message;
        }
        #endregion
    }
}