using System;

namespace WorkData.WeiXin.WeiXin
{
    /// <summary>
    /// 微信事件数据
    /// </summary>
    public class WeiXinEventArgs : EventArgs
    {
        /// <summary>
        /// 交互过程中产生的微信数据
        /// </summary>
        public string WeiXinData { get; set; }
    }

    /// <summary>
    /// 微信事件处理代理程序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void WeiXinEventHandler(object sender, WeiXinEventArgs args);
}