using System.Xml;
using Senparc.Weixin.MP.Entities;

namespace WorkData.WeiXin.Helper
{
    public class RequestMessageBaseHelper
    {
        /// <summary>
        /// 构建RequestMessageBase
        /// </summary>
        /// <param name="requestXml"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public RequestMessageBase BuildRequestMessageBase(XmlDocument requestXml, RequestMessageBase message)
        {
            RequestMessageBase requestMessageBase = null;

            var msgType = requestXml.GetText("//MsgType");
            switch (msgType)
            {
                case "text":
                    requestMessageBase = BuildRequestMessageText(requestXml, message);
                    break;
                case "image":
                    requestMessageBase = BuildRequestMessageImage(requestXml, message);
                    break;
                case "voice":
                    requestMessageBase = BuildRequestMessageVoice(requestXml, message);
                    break;
                case "video":
                case "shortvideo":
                    requestMessageBase = BuildRequestMessageVideo(requestXml, message);
                    break;
                case "location":
                    requestMessageBase = BuildRequestMessageLocation(requestXml, message);
                    break;
                case "link":
                    requestMessageBase = BuildRequestMessageLink(requestXml, message);
                    break;
                case "event":
                    requestMessageBase = BuildRequestMessageEvent(requestXml, message);
                    break;
                default:
                    break;
            }
            return requestMessageBase;
        }

        /// <summary>
        /// 构建RequestMessageText(文本消息)
        /// </summary>
        /// <param name="requestXml"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private RequestMessageText BuildRequestMessageText(XmlDocument requestXml, RequestMessageBase message)
        {
            var requestMessage = ToolHelper
              .AutoCopy<RequestMessageBase, RequestMessageText>(message);
            requestMessage.Content = requestXml.GetText("//Content");
            return requestMessage;
        }

        /// <summary>
        /// 构建RequestMessageImage(图片消息)
        /// </summary>
        /// <param name="requestXml"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private RequestMessageImage BuildRequestMessageImage(XmlDocument requestXml, RequestMessageBase message)
        {
            var requestMessage = ToolHelper
              .AutoCopy<RequestMessageBase, RequestMessageImage>(message);
            requestMessage.PicUrl = requestXml.GetText("//PicUrl");
            requestMessage.MediaId = requestXml.GetText("//MediaId");
            return requestMessage;
        }

        /// <summary>
        /// 构建RequestMessageLink(链接消息)
        /// </summary>
        /// <param name="requestXml"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private RequestMessageLink BuildRequestMessageLink(XmlDocument requestXml, RequestMessageBase message)
        {
            var requestMessage = ToolHelper
              .AutoCopy<RequestMessageBase, RequestMessageLink>(message);
            requestMessage.Url = requestXml.GetText("//Url");
            return requestMessage;
        }

        /// <summary>
        /// 构建RequestMessageLocation(地理位置消息)
        /// </summary>
        /// <param name="requestXml"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private RequestMessageLocation BuildRequestMessageLocation(XmlDocument requestXml, RequestMessageBase message)
        {
            var requestMessage = ToolHelper
              .AutoCopy<RequestMessageBase, RequestMessageLocation>(message);
            requestMessage.Scale = requestXml.GetInt32("//Scale");
            requestMessage.Label = requestXml.GetText("//Label");
            requestMessage.Location_X = requestXml.GetDouble("//Location_X");
            requestMessage.Location_Y = requestXml.GetDouble("//Location_Y");
            return requestMessage;
        }

        /// <summary>
        /// 构建RequestMessageVoice(语音消息)
        /// </summary>
        /// <param name="requestXml"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private RequestMessageVoice BuildRequestMessageVoice(XmlDocument requestXml, RequestMessageBase message)
        {
            var requestMessage = ToolHelper
              .AutoCopy<RequestMessageBase, RequestMessageVoice>(message);
            requestMessage.MediaId = requestXml.GetText("//MediaId");
            requestMessage.Format = requestXml.GetText("//Format");
            return requestMessage;
        }

        /// <summary>
        /// 构建RequestMessageVideo (视频消息)
        /// </summary>
        /// <param name="requestXml"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private RequestMessageVideo BuildRequestMessageVideo(XmlDocument requestXml, RequestMessageBase message)
        {
            var requestMessage = ToolHelper
              .AutoCopy<RequestMessageBase, RequestMessageVideo>(message);
            requestMessage.MediaId = requestXml.GetText("//MediaId");
            requestMessage.ThumbMediaId = requestXml.GetText("//ThumbMediaId");
            return requestMessage;
        }

        /// <summary>
        /// 构建RequestMessageVideo (视频消息)
        /// </summary>
        /// <param name="requestXml"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private RequestMessageBase BuildRequestMessageEvent(XmlDocument requestXml, RequestMessageBase message)
        {
            var eventType = requestXml.GetText("//Event");
            RequestMessageBase requestMessageBase = null;
            switch (eventType)
            {
                case "subscribe":  //订阅与扫码事件一起区别在于是否存在ticket
                    requestMessageBase = BuildRequestMessageEventSubscribe(requestXml, message);
                    break;
                case "unsubscribe"://取消订阅
                    requestMessageBase = BuildRequestMessageEventUnsubscribe(requestXml, message);
                    break;
                case "SCAN"://关注后扫码事件
                    requestMessageBase = BuildRequestMessageEventScan(requestXml, message);
                    break;
                case "LOCATION":
                    requestMessageBase = BuildRequestMessageEventLocation(requestXml, message);
                    break;
                case "CLICK":
                    requestMessageBase = BuildRequestMessageEventClick(requestXml, message);
                    break;
                case "VIEW":
                    requestMessageBase = BuildRequestMessageEventView(requestXml, message);
                    break;
                default:
                    break;
            }

            return requestMessageBase;
        }

        /// <summary>
        /// 构建RequestMessageEvent_Click (CLICK)
        /// </summary>
        /// <param name="requestXml"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private RequestMessageEvent_Click BuildRequestMessageEventClick(XmlDocument requestXml, RequestMessageBase message)
        {
            var requestMessage = ToolHelper
              .AutoCopy<RequestMessageBase, RequestMessageEvent_Click>(message);
            requestMessage.EventKey = requestXml.GetText("//EventKey");
            return requestMessage;
        }


        /// <summary>
        /// 构建RequestMessageEvent_Location  (Location)
        /// </summary>
        /// <param name="requestXml"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private RequestMessageEvent_Location BuildRequestMessageEventLocation(XmlDocument requestXml, RequestMessageBase message)
        {
            var requestMessage = ToolHelper
              .AutoCopy<RequestMessageBase, RequestMessageEvent_Location>(message);
            requestMessage.Latitude = requestXml.GetDouble("//Latitude");
            requestMessage.Longitude = requestXml.GetDouble("//Longitude");
            requestMessage.Precision = requestXml.GetDouble("//Precision");
            return requestMessage;
        }

        /// <summary>
        /// 构建RequestMessageEvent_View (View)
        /// </summary>
        /// <param name="requestXml"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private RequestMessageEvent_View BuildRequestMessageEventView(XmlDocument requestXml, RequestMessageBase message)
        {
            var requestMessage = ToolHelper
              .AutoCopy<RequestMessageBase, RequestMessageEvent_View>(message);
            requestMessage.EventKey = requestXml.GetText("//EventKey");
            return requestMessage;
        }

        /// <summary>
        /// 构建RequestMessageEvent_Subscribe  (Subscribe)
        /// </summary>
        /// <param name="requestXml"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private RequestMessageEvent_Subscribe BuildRequestMessageEventSubscribe(XmlDocument requestXml, RequestMessageBase message)
        {
            var requestMessage = ToolHelper
              .AutoCopy<RequestMessageBase, RequestMessageEvent_Subscribe>(message);
            requestMessage.EventKey = requestXml.GetText("//EventKey");
            requestMessage.Ticket = requestXml.GetText("//Ticket");
            return requestMessage;
        }


        /// <summary>
        /// 构建RequestMessageEvent_Subscribe  (Subscribe)
        /// </summary>
        /// <param name="requestXml"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private RequestMessageEvent_Unsubscribe BuildRequestMessageEventUnsubscribe(XmlDocument requestXml, RequestMessageBase message)
        {
            var requestMessage = ToolHelper
              .AutoCopy<RequestMessageBase, RequestMessageEvent_Unsubscribe>(message);
            return requestMessage;
        }


        /// <summary>
        /// 构建BuildRequestMessageEventScan (Scan)
        /// </summary>
        /// <param name="requestXml"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private RequestMessageEvent_Scan BuildRequestMessageEventScan(XmlDocument requestXml, RequestMessageBase message)
        {
            var requestMessage = ToolHelper
              .AutoCopy<RequestMessageBase, RequestMessageEvent_Scan>(message);
            requestMessage.EventKey = requestXml.GetText("//EventKey");
            requestMessage.Ticket = requestXml.GetText("//Ticket");

            return requestMessage;
        }

    }
}

