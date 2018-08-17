namespace WorkData.WeiXin.Interface
{
    public interface ILocalAuthenticationService
    {
        /// <summary>
        /// 验证回调地址
        /// </summary>
        void VerifyCallBackUrl();

        /// <summary>
        /// 回调处理程序
        /// <para>
        /// callback 返回Null或 XML格式字符串
        /// </para>
        /// </summary>
        void CallbackHandle();

        /// <summary>
        /// 自动注册
        /// </summary>
        /// <param name="weiXinNumber"></param>
        void AutoRegister(string weiXinNumber);

        /// <summary>
        /// Authorize
        /// </summary>
        void Authorize(string code, string returnUrl);

        /// <summary>
        /// RedirectUrl
        /// </summary>
        string RedirectUrl(string returnUrl);
    }
}