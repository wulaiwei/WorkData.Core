// ------------------------------------------------------------------------------
// Copyright  成都积微物联电子商务有限公司 版权所有。
// 项目名：Jwell.Wechat.Common
// 文件名：WechatAppSettings.cs
// 创建标识：吴来伟 2017-03-16
// 创建描述：
//
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

namespace WorkData.WeiXin.Config
{
    public class WechatAppSettings
    {
        public string AppId { get; set; }
        public string Token { get; set; }
        public string CorpId { get; set; }
        public string CorpSecret { get; set; }
        public string EncodingAesKey { get; set; }
        public string AuthorizeUrl { get; set; }
    }
}