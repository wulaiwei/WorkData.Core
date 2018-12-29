using Senparc.Weixin.MP.Entities.Request;

namespace WorkData.WeiXin.Interface
{
    public interface ILocalAuthenticationService
    {
        /// <summary>
        /// 验证回调地址
        /// </summary>
        bool VerifyCallBackUrl(PostModel postModel, string echostr);

        /// <summary>
        /// 回调处理程序
        /// <para>
        /// callback 返回Null或 XML格式字符串
        /// </para>
        /// </summary>
        bool CallbackHandle(PostModel postModel);

        /// <summary>
        /// Authorize
        /// </summary>
        string Authorize(string code, string returnUrl);
    }
}