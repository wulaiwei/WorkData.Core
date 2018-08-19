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

        public static string AppId { get; set; }
        public static string Token { get; set; }
        public static string CorpId { get; set; }
        public static string CorpSecret { get; set; }
        public static string EncodingAesKey { get; set; }
        public static string AuthorizeUrl { get; set; }
    }
}