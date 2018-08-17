/*----------------------------------------------------------------
    Copyright (C) 2017 Senparc

    文件名：CustomMessageHandler.cs
    文件功能描述：微信公众号自定义MessageHandler

    创建标识：Senparc - 20150312
----------------------------------------------------------------*/

using System.Text.RegularExpressions;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.MessageHandlers;

namespace WorkData.WeiXin.CustomMessageHandlers
{
    /// <summary>
    /// 消息流
    /// </summary>
    public class CustomMessageHandler : MessageHandler<CustomMessageContext>
    {
        #region 数据库操作可打开

        //    private readonly IRepository<SubscriptionMessage, int> _subscriptionMessageRepository;
        //    _subscriptionMessageRepository = IocManager
        //.Instance
        //.Resolve<IRepository<SubscriptionMessage, int>>();

        #endregion 数据库操作可打开

        public CustomMessageHandler(RequestMessageBase requestMessage)
         : base(requestMessage)
        {
        }

        /// <summary>
        /// 默认消息
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            //var responseMessage = base.CreateResponseMessage<ResponseMessageText>(); //ResponseMessageText也可以是News等其他类型
            //responseMessage.Content = "";

            //return responseMessage;
            return null;//返回null视为向微信服务器发送“success”，服务器收到以后不会有任何动作
        }

        /// <summary>
        /// 文本消息
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            //\r\n用于换行，requestMessage.Content即用户发过来的文字内容
            if (Regex.IsMatch(requestMessage.Content,"[0-9]"))
            {
                responseMessage.Content = "您发送了一条包含数字的消息：" + requestMessage.Content;
            }
            else
            {
                return null;//返回null视为向微信服务器发送“success”，服务器收到以后不会有任何动作
            }
            return responseMessage;
        }

        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ClickRequest(RequestMessageEvent_Click requestMessage)
        {
            IResponseMessageBase reponseMessage = null;
            //菜单点击，需要跟创建菜单时的Key匹配
            switch (requestMessage.EventKey)
            {
                case "DoBtn":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageNews>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Articles.Add(new Article()
                        {
                            Title = "您点击了子菜单图文按钮",
                            Description = "您点击了子菜单图文按钮，这是一条图文信息。这个区域是Description内容\r\n可以使用\\r\\n进行换行。",
                            PicUrl = "http://sdk.weixin.senparc.com/Images/qrcode.jpg",
                            Url = "http://sdk.weixin.senparc.com"
                        });
                    }
                    break;

                default:
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        strongResponseMessage.Content = "您点击了按钮，EventKey：" + requestMessage.EventKey;
                        reponseMessage = strongResponseMessage;
                    }
                    break;
            }

            return reponseMessage;
        }

        ///// <summary>
        ///// 打开网页事件
        ///// </summary>
        ///// <param name="requestMessage"></param>
        ///// <returns></returns>
        //public override IResponseMessageBase OnEvent_ViewRequest(RequestMessageEvent_View requestMessage)
        //{
        //    //说明：这条消息只作为接收，下面的responseMessage到达不了客户端，类似OnEvent_UnsubscribeRequest
        //    var responseMessage = CreateResponseMessage<ResponseMessageText>();
        //    responseMessage.Content = "您点击了view按钮，将打开网页：" + requestMessage.EventKey;
        //    return responseMessage;
        //}

        #region 可重写接口

        //https://github.com/JeffreySu/WeiXinMPSDK/blob/master/src/Senparc.Weixin.MP.Sample/Senparc.Weixin.MP.Sample.CommonService/MessageHandlers/CustomMessageHandler/CustomMessageHandler_Events.cs
        //https://github.com/JeffreySu/WeiXinMPSDK/blob/master/src/Senparc.Weixin.MP.Sample/Senparc.Weixin.MP.Sample.CommonService/MessageHandlers/CustomMessageHandler/CustomMessageHandler.cs
        //public virtual IResponseMessageBase OnImageRequest(RequestMessageImage requestMessage);
        //public virtual IResponseMessageBase OnLinkRequest(RequestMessageLink requestMessage);
        //public virtual IResponseMessageBase OnLocationRequest(RequestMessageLocation requestMessage);
        //public virtual IResponseMessageBase OnTextRequest(RequestMessageText requestMessage);
        //public virtual IResponseMessageBase OnVoiceRequest(RequestMessageVoice requestMessage);
        //public virtual IResponseMessageBase OnVideoRequest(RequestMessageVideo requestMessage);

        //public virtual IResponseMessageBase OnEvent_ClickRequest(RequestMessageEvent_Click requestMessage);
        //public virtual IResponseMessageBase OnEvent_ViewRequest(RequestMessageEvent_View requestMessage);
        //public virtual IResponseMessageBase OnEvent_EnterRequest(RequestMessageEvent_Enter requestMessage);
        //public virtual IResponseMessageBase OnEvent_LocationRequest(RequestMessageEvent_Location requestMessage);
        //public virtual IResponseMessageBase OnEvent_SubscribeRequest(RequestMessageEvent_Subscribe requestMessage);
        //public virtual IResponseMessageBase OnEvent_UnsubscribeRequest(RequestMessageEvent_Unsubscribe requestMessage);
        //public virtual IResponseMessageBase OnEvent_ScanRequest(RequestMessageEvent_Scan requestMessage)
        //public virtual IResponseMessageBase OneEvent_MassSendJobFinisRequest(RequestMessageEvent_MassSendJobFinish requestMessage)

        #endregion 可重写接口

        #region Aop

        /// <summary>
        /// 执行之前
        /// </summary>
        public override void OnExecuting()
        {
            if (CurrentMessageContext.StorageData == null)
            {
                CurrentMessageContext.StorageData = 0;
            }
            base.OnExecuting();
        }

        /// <summary>
        /// 执行之后
        /// </summary>
        public override void OnExecuted()
        {
            base.OnExecuted();
            CurrentMessageContext.StorageData = ((int)CurrentMessageContext.StorageData) + 1;
        }

        #endregion Aop
    }
}