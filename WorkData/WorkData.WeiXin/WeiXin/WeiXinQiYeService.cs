#region 导入名称空间

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Xml;
using Jwell.Wechat.Common.Helper;
using LightWork.WeiXin;
using Newtonsoft.Json;
using ServiceStack;
using Tencent;
using WorkData.WeiXin.WeiXin.Model;

#endregion 导入名称空间

namespace WorkData.WeiXin.WeiXin
{
    public class WeiXinQiYeService : IWeiXinQiYeService
    {
        private readonly WeiXinConfig _config;
        private readonly WXBizMsgCrypt _wxCrypt;

        public WeiXinQiYeService(WeiXinConfig config)
        {
            _config = config;
            _wxCrypt = new WXBizMsgCrypt(_config.Token, _config.EncodingAesKey, _config.CorpId);
            _config.CompletedGetAccessToken += _config_CompletedGetAccessToken;
        }

        private void _config_CompletedGetAccessToken(object sender, WeiXinEventArgs args)
        {
            GetAccessTokenCompleted?.Invoke(sender, args);
        }

        /// <summary>
        /// 获取访问令牌完成事件
        /// </summary>
        public event WeiXinEventHandler GetAccessTokenCompleted;

        /// <summary>
        /// （回调模式,未解密）准备解密用户请求事件
        /// </summary>
        public event WeiXinEventHandler DecryptReady;

        /// <summary>
        /// （回调模式，已解密）用户请求完成解密事件
        /// </summary>
        public event WeiXinEventHandler DecryptCompleted;

        /// <summary>
        /// （回调模式）响应消息准备加密事件
        /// </summary>
        public event WeiXinEventHandler EncryptReady;

        /// <summary>
        /// （回调模式）响应消息完成加密事件
        /// </summary>
        public event WeiXinEventHandler EncryptCompleted;

        /// <summary>
        /// 推送消息响应完成
        /// </summary>
        public event WeiXinEventHandler PushMessageCompleted;

        /// <summary>
        /// 获取用户信息
        /// </summary>
        public event WeiXinEventHandler OAuth2GetUserInfoCompleted;

        /// <summary>
        /// 验证回调地址（回调模式）
        /// </summary>
        public void VerifyCallBackUrl()
        {
            var verifyMessageSignature = HttpHelper.ParseUrl("msg_signature");
            var verifyTimeStamp = HttpHelper.ParseUrl("timestamp");
            var verifyNonce = HttpHelper.ParseUrl("nonce");
            var verifyEchoStr = HttpHelper.ParseUrl("echostr");

            var plainTextEchoStr = "";
            var returnCode = _wxCrypt.VerifyUrl(verifyMessageSignature, verifyTimeStamp, verifyNonce, verifyEchoStr,
                ref plainTextEchoStr);
            if (returnCode != ReturnCode.C0)
            {
                throw new WeiXinException(returnCode);
            }

            HttpHelper.SetResponse(plainTextEchoStr); //返回明文到企业号
        }

        /// <summary>
        /// 回调处理程序
        /// <para>
        /// callback 返回Null或 XML格式字符串
        /// </para>
        /// </summary>
        /// <param name="callback">回调代理（返回Null或 XML格式字符串）</param>
        public void CallbackHandle(Func<XmlDocument, string> callback)
        {
            var requestXml = DecryptRequest();
            var xml = new XmlDocument();
            xml.LoadXml(requestXml);
            var callbackData = callback(xml);

            if (string.IsNullOrEmpty(callbackData) || string.IsNullOrWhiteSpace(callbackData))
            {
            }
        }

        /// <summary>
        /// 解密用户请求消息（回调模式）
        /// </summary>
        private string DecryptRequest()
        {
            var requestMessageSingnature = HttpHelper.ParseUrl("msg_signature");
            var requestTimeStamp = HttpHelper.ParseUrl("timestamp");
            var requestNonce = HttpHelper.ParseUrl("nonce");
            var requestData = HttpHelper.GetPost(); //加密数据

            DecryptReady?.Invoke(this, new WeiXinEventArgs { WeiXinData = requestData });

            var requestPlainText = ""; // 解析之后的明文
            var returnCode = _wxCrypt.DecryptMsg(requestMessageSingnature, requestTimeStamp,
                requestNonce, requestData, ref requestPlainText);
            if (returnCode != 0)
            {
                throw new WeiXinException(returnCode);
            }

            DecryptCompleted?.Invoke(this, new WeiXinEventArgs { WeiXinData = requestPlainText });
            return requestPlainText;
        }

        /// <summary>
        /// 响应加密消息（回调模式）
        /// </summary>
        /// <param name="responseXml"></param>
        private void EncryptResponse(string responseXml)
        {
            var requestTimeStamp = HttpHelper.ParseUrl("timestamp");
            var requestNonce = HttpHelper.ParseUrl("nonce");

            EncryptReady?.Invoke(this, new WeiXinEventArgs { WeiXinData = responseXml });

            var encryptMessage = ""; //xml格式的密文
            var returnCode = _wxCrypt.EncryptMsg(responseXml, requestTimeStamp, requestNonce, ref encryptMessage);
            if (returnCode != 0)
            {
                throw new WeiXinException(returnCode.GetDescription());
            }
            EncryptCompleted?.Invoke(this, new WeiXinEventArgs { WeiXinData = encryptMessage });
            HttpHelper.SetResponse(encryptMessage);
        }

        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="agentId">企业应用的id，整型。可在应用的设置页面查看</param>
        /// <param name="touser"> 成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。特殊情况：指定为@all，则向关注该企业应用的全部成员发送 </param>
        /// <param name="toparty">部门ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数</param>
        /// <param name="totag">标签ID列表，多个接收者用‘|’分隔。当touser为@all时忽略本参数</param>
        /// <param name="articles">
        ///     <para>最多10条</para>
        /// </param>
        public void PushMessage(string agentId, string touser, string toparty, string totag, List<WeiXinArticle> articles)
        {
            var newsMessage = new NewsMessage();
            newsMessage.AgentId = agentId;
            newsMessage.ToUser = touser;
            newsMessage.ToTag = totag;
            newsMessage.ToParty = toparty;
            newsMessage.News.Articles.AddRange(articles);

            //发送数据
            var jsonData = JsonConvert.SerializeObject(newsMessage);
            var pushUrl = _config.GetPushMessageUrl();
            var response = pushUrl.PostJsonToUrl(jsonData, RequestFilter, ResponseFilter);
            PushMessageCompleted?.Invoke(this, new WeiXinEventArgs { WeiXinData = response });
            var respMessage = JsonConvert.DeserializeObject<ResponseMessage>(response);
            var returnCode = ReturnCodeExtend.GetReturnCode(respMessage.ErrCode);
            if (returnCode != ReturnCode.C0)
            {
                throw new WeiXinException(returnCode);
            }
        }


        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="json">推送数据</param>
        public void PushMessage(string json)
        {
            //发送数据
            var pushUrl = _config.GetPushMessageUrl();
            var response = pushUrl.PostJsonToUrl(json, RequestFilter, ResponseFilter);
            PushMessageCompleted?.Invoke(this, new WeiXinEventArgs { WeiXinData = response });
            var respMessage = JsonConvert.DeserializeObject<ResponseMessage>(response);
            var returnCode = ReturnCodeExtend.GetReturnCode(respMessage.ErrCode);
            if (returnCode != ReturnCode.C0)
            {
                throw new WeiXinException(returnCode);
            }
        }

        /// <summary>
        /// 获取成员
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>
        /// <![CDATA[
        /// {
        ///"errcode": 0,
        ///"errmsg": "ok",
        ///"userid": "zhangsan",
        ///"name": "李四",
        ///"department": [1, 2],
        ///"position": "后台工程师",
        ///"mobile": "15913215421",
        ///"gender": "1",
        ///"email": "zhangsan@gzdev.com",
        ///"weixinid": "lisifordev",
        ///"avatar": "http://wx.qlogo.cn/mmopen/ajNVdqHZLLA3WJ6DSZUfiakYe37PKnQhBIeOQBO4czqrnZDS79FH5Wm5m4X69TBicnHFlhiafvDwklOpZeXYQQ2icg/0",
        ///"status": 1,
        ///"extattr": {"attrs":[{"name":"爱好","value":"旅游"},{"name":"卡号","value":"1234567234"}]}
        ///}
        /// ]]>
        /// </returns>
        public string GetJsonForMember(string userId)
        {
            var getMemberUrl = _config.GetMemberUrl(userId);
            var response = getMemberUrl.GetStringFromUrl();
            dynamic dynamicMember = JsonConvert.DeserializeObject<ExpandoObject>(response);
            var returnCode = ReturnCodeExtend.GetReturnCode(dynamicMember.errcode);
            if (returnCode != ReturnCode.C0)
            {
                throw new WeiXinException(returnCode);
            }

            return response;
        }

        /// <summary>
        /// 获取企业信息 Json 格式
        /// </summary>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public string GetJsonForEnterpriseInfo(string agentId)
        {
            var response = _config.GetQiYeInfoUrl(agentId).GetJsonFromUrl();
            dynamic dynamicMember = JsonConvert.DeserializeObject<ExpandoObject>(response);
            var returnCode = ReturnCodeExtend.GetReturnCode(dynamicMember.errcode);
            if (returnCode != ReturnCode.C0)
            {
                throw new WeiXinException(returnCode);
            }

            return response;
        }

        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetUserId(string code)
        {
            var getUserInfoUrl = _config.GetUserInfoUrl(code);
            var response = getUserInfoUrl.GetJsonFromUrl();
            OAuth2GetUserInfoCompleted?.Invoke(this, new WeiXinEventArgs { WeiXinData = response });
            //{"UserId":"0031","DeviceId":"9cfa45ff3b26194c5078a711b0fc71f7"}
            dynamic dynamicUser = JsonConvert.DeserializeObject<ExpandoObject>(response);
            var dynamicDicStyle = (IDictionary<string, object>)dynamicUser;

            if (dynamicDicStyle.ContainsKey("errcode"))
            {
                return null;
            }
            if (dynamicDicStyle.Keys.Contains("UserId"))
            {
                return (string)dynamicUser.UserId;
            }
            else
            {
                return (string)dynamicUser.OpenId;
            }
        }

        private void RequestFilter(HttpWebRequest httpWebRequest)
        {
            httpWebRequest.ProtocolVersion = Version.Parse("1.0");
            httpWebRequest.Timeout = 60 * 1000;
        }

        private void ResponseFilter(HttpWebResponse httpWebResponse)
        {
            //do something here ……
        }
    }
}