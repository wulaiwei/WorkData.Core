// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Web
// 文件名：ResponseOAuthViewModel.cs
// 创建标识：吴来伟 2018-06-22 10:01
// 创建描述：
//
// 修改标识：吴来伟2018-06-22 10:01
// 修改描述：
//  ------------------------------------------------------------------------------

using Newtonsoft.Json;
using System;

namespace WorkData.Web.Models.OAuths
{
    public class ResponseOAuthViewModel
    {
        /// <summary>
        /// token
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 刷新Token
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// 当前时间
        /// </summary>
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        /// <summary>
        /// 过期时间(单位分钟)
        /// </summary>
        [JsonProperty("token_expires")]
        public int TokenExpires { get; set; }

        /// <summary>
        /// 刷新时间(单位为秒)
        /// </summary>
        [JsonProperty("refresh_token_expires")]
        public int RefreshTokenExpires { get; set; }

        /// <summary>
        /// token类型
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; } = "Bearer";
    }
}