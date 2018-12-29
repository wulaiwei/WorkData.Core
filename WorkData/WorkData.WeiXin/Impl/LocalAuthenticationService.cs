using Senparc.Weixin;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP.Entities.Request;
using System;
using System.Linq;
using WorkData.Code.Repositories;
using WorkData.Dependency;
using WorkData.Domain.WeiXin;
using WorkData.WeiXin.Config;
using WorkData.WeiXin.Interface;

namespace WorkData.WeiXin.Impl
{
    public class LocalAuthenticationService : ILocalAuthenticationService
    {
        public WechatAppSettings WechatAppSettings => IocManager.Instance.ResolveServiceValue<WechatAppSettings>();

        private readonly IBaseRepository<WeiXinUserInfo, string> _baseRepository;

        public LocalAuthenticationService(IBaseRepository<WeiXinUserInfo, string> baseRepository)
        {
            _baseRepository = baseRepository;
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

            if (oAuthAccessTokenResult == null)
                throw new Exception("错误消息:oAuthAccessTokenResult为空");

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
            var item = _baseRepository.GetAll().FirstOrDefault(x => x
                                                                        .OpenId == userInfo.openid);
            if (item == null)
            {
                var model = new WeiXinUserInfo
                {
                    City = userInfo.city,
                    Country = userInfo.country,
                    HeadImgUrl = userInfo.headimgurl,
                    NickName = userInfo.nickname,
                    OpenId = userInfo.openid,
                    Province = userInfo.province,
                    Sex = userInfo.sex.ToString(),
                    UnionId = userInfo.unionid
                };
                _baseRepository.Insert(model);
            }

            if (returnUrl.Contains("?"))
            {
                returnUrl = returnUrl + "&access_token=" + oAuthAccessTokenResult.access_token + "&openid=" + oAuthAccessTokenResult.openid;
            }
            else
            {
                returnUrl = returnUrl + "?access_token=" + oAuthAccessTokenResult.access_token + "&openid=" + oAuthAccessTokenResult.openid;
            }

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