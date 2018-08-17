using System;
using System.Xml;
using Jwell.Wechat.Common.Helper;
using Senparc.CO2NET.Extensions;
using Senparc.Weixin;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP.Entities;
using WorkData.WeiXin.Config;
using WorkData.WeiXin.CustomMessageHandlers;
using WorkData.WeiXin.Helper;
using WorkData.WeiXin.Interface;

namespace WorkData.WeiXin
{
    public class LocalAuthenticationService : ILocalAuthenticationService
    {
        /// <summary>
        /// 验证回调
        /// </summary>
        public void VerifyCallBackUrl()
        {
            var verifyMessageSignature = HttpHelper.ParseUrl("signature");
            var verifyTimeStamp = HttpHelper.ParseUrl("timestamp");
            var verifyNonce = HttpHelper.ParseUrl("nonce");
            var verifyEchoStr = HttpHelper.ParseUrl("echostr");

            if (CheckSignature.Check(verifyMessageSignature, verifyTimeStamp, verifyNonce, WechatAppSettings.WechatManagement.Token))
            {
                HttpHelper.SetResponse(verifyEchoStr);
            }
            else
            {
                HttpHelper.SetResponse("failed:" + verifyMessageSignature);
            }
        }

        /// <summary>
        /// 微信回调
        /// </summary>
        public void CallbackHandle()
        {
            //获取数据
            var requestXml = HttpHelper.GetPost();
            var xml = new XmlDocument();
            xml.LoadXml(requestXml);

            var callbackData = RequestResponse(xml);

            if (string.IsNullOrEmpty(callbackData) || string.IsNullOrWhiteSpace(callbackData))
            {
                callbackData = "";
            }
            HttpHelper.SetResponse(callbackData);
        }

        /// <summary>
        /// 自动注册
        /// </summary>
        /// <param name="openId"></param>
        public void AutoRegister(string openId)
        {
            var weChatHelper = new WeChatHelper
                (
                    WechatAppSettings.WechatManagement.AppId,
                    WechatAppSettings.WechatManagement.CorpSecret
                );
            //加载用户信息
            var info= weChatHelper.GetUser(openId);
            //TODO 业务代码

        }

        /// <summary>
        /// RedirectUrl
        /// </summary>
        /// <param name="returnUrl"></param>
        public string RedirectUrl(string returnUrl)
        {
            var state = "JeffreySu-" + DateTime.Now.Millisecond;
            //随机数，用于识别请求可靠性
            var url = OAuthApi.GetAuthorizeUrl(
                 WechatAppSettings.WechatManagement.AppId,
                $"{WechatAppSettings.WechatManagement.AuthorizeUrl}?returnUrl=" + returnUrl.UrlDecode(),
                state, OAuthScope.snsapi_userinfo);
            return url;
        }

        /// <summary>
        /// Authorize
        /// </summary>
        /// <param name="code"></param>
        /// <param name="returnUrl"></param>
        public void Authorize(string code ,string returnUrl)
        {
            OAuthAccessTokenResult oAuthAccessTokenResult = null;
            try
            {
                oAuthAccessTokenResult = OAuthApi.GetAccessToken(
                 WechatAppSettings.WechatManagement.AppId,
                 WechatAppSettings.WechatManagement.CorpSecret,
                 code);

                var userInfo = OAuthApi.GetUserInfo(
                    oAuthAccessTokenResult.access_token, 
                    oAuthAccessTokenResult.openid
                    );
                returnUrl = returnUrl + "?access_token=" + oAuthAccessTokenResult.access_token + "&openid=" + oAuthAccessTokenResult.openid;

                HttpHelper.SetResponseRedirect(returnUrl);

            }
            catch (Exception ex)
            {
                HttpHelper.SetResponse("错误消息:"+ex.Message);
            }

            if (oAuthAccessTokenResult != null 
                && oAuthAccessTokenResult.errcode
                != ReturnCode.请求成功)
            {
                HttpHelper.SetResponse("错误消息:" + oAuthAccessTokenResult.errmsg);
            }
        }

        /// <summary>
        /// Request
        /// </summary>
        /// <param name="requestXml"></param>
        /// <returns></returns>
        private string RequestResponse(XmlDocument requestXml)
        {
            var message = new RequestMessageBase()
            {
                CreateTime = DateTime.Now,
                FromUserName = requestXml.GetText("//FromUserName"),
                ToUserName = requestXml.GetText("//ToUserName"),
                MsgId = requestXml.GetInt64("//MsgId")
            };

            var requestMessageBaseHelper = new RequestMessageBaseHelper();

            var requestMessageBase = requestMessageBaseHelper.BuildRequestMessageBase(requestXml, message);

            var messageHandlers = new CustomMessageHandler(requestMessageBase);

            messageHandlers.Execute();

            return messageHandlers.ResponseDocument == null ? "success" : messageHandlers.ResponseDocument.ToString();
        }
    }
}