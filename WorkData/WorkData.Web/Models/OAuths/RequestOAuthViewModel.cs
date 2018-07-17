// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Web
// 文件名：RequestOAuthViewModel.cs
// 创建标识：吴来伟 2018-06-22 9:59
// 创建描述：
//
// 修改标识：吴来伟2018-06-22 9:59
// 修改描述：
//  ------------------------------------------------------------------------------
using Newtonsoft.Json;

namespace WorkData.Web.Models.OAuths
{
    public class RequestOAuthViewModel
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}