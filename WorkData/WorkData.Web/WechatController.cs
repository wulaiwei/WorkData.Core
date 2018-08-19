using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin.MP.Entities.Request;
using WorkData.Code.Webs.Infrastructure;
using WorkData.Dependency;
using WorkData.WeiXin.Config;
using WorkData.WeiXin.Interface;

namespace WorkData.Web
{
    public class WechatController : WorkDataBaseController
    {
        public WechatAppSettings WechatAppSettings => IocManager.Instance.Resolve<WechatAppSettings>();
        private readonly ILocalAuthenticationService _authSrv;

        public WechatController(
                        ILocalAuthenticationService authSrv
            )
        {
            _authSrv = authSrv;
        }

        /// <summary>
        ///验证回调地址
        /// </summary>
        [HttpGet, ActionName("WeiXinCallBackHandler")]
        public ActionResult VerifyCallBackUrl(PostModel postModel, string echostr)
        {
            if (_authSrv.VerifyCallBackUrl(postModel, echostr))
            {
                return Content(echostr); //返回随机字符串则表示验证通过
            }
            else
            {
                return Content("failed:" + postModel.Signature + "," +
                    Senparc.Weixin.MP.CheckSignature.GetSignature(postModel.Timestamp, postModel.Nonce,
                    WechatAppSettings.Token) + "。" +
                    "如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
            }
        }

        /// <summary>
        /// 处理微信回调
        /// </summary>
        /// <returns></returns>
        [HttpPost, ActionName("WeiXinCallBackHandler")]
        public ActionResult CallbackHandle(PostModel postModel)
        {
            _authSrv.CallbackHandle(postModel);
            return null;
        }

        #region 微信OAuth授权回调地址 AuthorizeUrl(string code, string state, string rurl)
        /// <summary>
        /// 授权并跳转
        /// </summary>
        /// <param name="code">用户同意授权后，返回的code，用于获取access_token获取用户信息</param>
        /// <param name="state">state参数，这里传递公众号id</param>
        /// <param name="returnUrl"></param>
        public ActionResult AuthorizeUrl(string code, string state, string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(code) || code == "authdeny")
                return Content("授权失败");

            _authSrv.Authorize(code, returnUrl);

            return null;
        }
        
        #endregion 微信OAuth授权回调地址 AuthorizeUrl(string code, string state, string rurl)
    }
}
