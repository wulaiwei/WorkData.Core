namespace WorkData.WeiXin.WeiXin.Model
{
    /// <summary>
    /// 微信回调模式处理程序返回数据
    /// </summary>
    public class WeiXinCallBackHandleData
    {
        /// <summary>
        ///需要响应(默认 true)
        /// </summary>
        public bool NeedResponse { get; set; } = true;

        /// <summary>
        /// 响应的XML（默认 null）
        /// </summary>
        public string ResponseXml { get; set; } = null;
    }
}