using Senparc.Weixin;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP.Entities.Request;
using System;
using System.Collections.Generic;
using System.Text;
using WorkData.Dependency;
using WorkData.WeiXin.Config;
using WorkData.WeiXin.Interface;

namespace WorkData.WeiXin.Impl
{
    public class LocalAuthenticationService : ILocalAuthenticationService
    {
        public WechatAppSettings WechatAppSettings => IocManager.Instance.Resolve<WechatAppSettings>();

        public LocalAuthenticationService()
        {

        }

        /// <summary>
        /// 授权
        /// </summary>
        /// <param name="code"></param>
        /// <param name="returnUrl"></param>
        public string Authorize(string code, string returnUrl)
        {
            OAuthAccessTokenResult oAuthAccessTokenResult = null;

            oAuthAccessTokenResult = OAuthApi.GetAccessToken(
             WechatAppSettings.AppId,
             WechatAppSettings.CorpSecret,
             code);

            if (oAuthAccessTokenResult != null
                && oAuthAccessTokenResult.errcode
                != ReturnCode.请求成功)
            {
                throw new Exception("错误消息:" + oAuthAccessTokenResult.errmsg);
            }

            var userInfo = OAuthApi.GetUserInfo(
                oAuthAccessTokenResult.access_token,
                oAuthAccessTokenResult.openid
                );
            returnUrl = returnUrl + "?access_token=" + oAuthAccessTokenResult.access_token + "&openid=" + oAuthAccessTokenResult.openid;

            return returnUrl;
        }

        /// <summary>
        /// 消息回调
        /// </summary>
        /// <param name="postModel"></param>
        /// <returns></returns>
        public bool CallbackHandle(PostModel postModel)
        {
            if (!CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, WechatAppSettings.Token))
            {
                throw new Exception("参数错误");
            }

            postModel.Token = WechatAppSettings.Token;//根据自己后台的设置保持一致
            postModel.EncodingAESKey = WechatAppSettings.EncodingAesKey;//根据自己后台的设置保持一致
            postModel.AppId = WechatAppSettings.AppId;//根据自己后台的设置保持一致

            //todo  重写WxOpenMessageHandler
            return true;
        }

        /// <summary>
        /// VerifyCallBackUrl
        /// </summary>
        /// <param name="postModel"></param>
        /// <param name="echostr"></param>
        /// <returns></returns>
        public bool VerifyCallBackUrl(PostModel postModel, string echostr)
        {
            return CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, WechatAppSettings.Token);
        }
    }
}
