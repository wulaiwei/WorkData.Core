using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senparc.CO2NET.Extensions;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.Helpers;
using WorkData.BaseWeb.Infrastructure;
using WorkData.Code.Repositories;
using WorkData.Dependency;
using WorkData.Domain.WeiXin;
using WorkData.Web.Models.WeiXinShare;
using WorkData.WeiXin.Config;
using WorkData.WeiXin.Interface;

namespace WorkData.Web
{
    public class WechatController : WorkDataBaseController
    {
        private readonly ILocalAuthenticationService _authSrv;
        private readonly IBaseRepository<WeiXinShare, string> _baseRepository;

        public WechatController(
            ILocalAuthenticationService authSrv, IBaseRepository<WeiXinShare, string> baseRepository)
        {
            _authSrv = authSrv;
            _baseRepository = baseRepository;
        }

        public WechatAppSettings WechatAppSettings => IocManager.Instance.ResolveServiceValue<WechatAppSettings>();

        /// <summary>
        ///     验证回调地址
        /// </summary>
        [HttpGet]
        [ActionName("WeiXinCallBackHandler")]
        public IActionResult VerifyCallBackUrl(PostModel postModel, string echostr)
        {
            if (_authSrv.VerifyCallBackUrl(postModel, echostr))
                return Content(echostr); //返回随机字符串则表示验证通过
            return Content("failed:" + postModel.Signature + "," +
                           CheckSignature.GetSignature(postModel.Timestamp, postModel.Nonce,
                               WechatAppSettings.Token) + "。" +
                           "如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
        }

        /// <summary>
        ///     处理微信回调
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("WeiXinCallBackHandler")]
        public IActionResult CallbackHandle(PostModel postModel)
        {
            _authSrv.CallbackHandle(postModel);
            return null;
        }

        #region 微信OAuth授权回调地址 AuthorizeUrl(string code, string state, string rurl)

        /// <summary>
        ///     授权并跳转
        /// </summary>
        /// <param name="code">用户同意授权后，返回的code，用于获取access_token获取用户信息</param>
        /// <param name="state">state参数，这里传递公众号id</param>
        /// <param name="returnUrl"></param>
        public IActionResult AuthorizeUrl(string code, string state, string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(code) || code == "authdeny")
                return Content("授权失败");

            var url = _authSrv.Authorize(code, returnUrl);

            return Redirect(url);
        }

        #endregion 微信OAuth授权回调地址 AuthorizeUrl(string code, string state, string rurl)

        /// <summary>
        ///     ShareAuthorizeUrl
        /// </summary>
        /// <param name="reurnUrl"></param>
        /// <returns></returns>
        public IActionResult ShareAuthorizeUrl(string reurnUrl)
        {
            var state = "JeffreySu-" + DateTime.Now.Millisecond; //随机数，用于识别请求可靠性
            var url = OAuthApi.GetAuthorizeUrl(WechatAppSettings.AppId,
                "http://www.mblogs.top/Wechat/AuthorizeUrl?returnUrl=" + reurnUrl.UrlEncode(),
                state, OAuthScope.snsapi_userinfo);

            return Redirect(url);
        }

        /// <summary>
        ///     分享
        /// </summary>
        /// <returns></returns>
        public IActionResult Share()
        {
            var shareEnum = ShareEnum.默认;
            var openId = Request.Query["openid"];
            var shareId = Request.Query["shareid"];
            if (string.IsNullOrWhiteSpace(openId))
            {
                shareEnum = ShareEnum.非法;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(shareId))
                    shareEnum = openId != shareId ? ShareEnum.分享点赞 : ShareEnum.分享无法点赞;
            }

            var reurnUrl = "http://www.mblogs.top/Wechat/Share?shareid=" + openId;

            var model = new WeiXinShareLikeViewModel
            {
                OpenId = openId,
                ShareId = shareId,
                Url = "http://www.mblogs.top/Wechat/ShareAuthorizeUrl?reurnUrl=" + reurnUrl
            };
            ViewBag.WeiXinShareLike = model;
            ViewBag.ShareEnum = shareEnum;

            var jssdkUiPackage = JSSDKHelper.GetJsSdkUiPackage(WechatAppSettings.AppId, WechatAppSettings.CorpSecret,
                Request.AbsoluteUri());
            return View(jssdkUiPackage);
        }

        /// <summary>
        ///     排行榜
        /// </summary>
        /// <returns></returns>
        public IActionResult Ranking()
        {
            var data = _baseRepository.GetAll();
            var item = (from weiXinShare in data
                group weiXinShare by new
                {
                    weiXinShare.ShareOpenId,
                    weiXinShare.ShareOpenNick
                }
                into g
                select new RankingViewModel
                {
                    ShareOpenId = g.Key.ShareOpenId,
                    ShareOpenNick = g.Key.ShareOpenNick,
                    Count = g.Count()
                }).OrderByDescending(x => x.Count).ToList();

            return View(item);
        }
    }
}