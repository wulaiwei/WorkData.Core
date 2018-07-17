// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：WorkDataJwtPayload.cs
// 创建标识：吴来伟 2018-06-11 14:02
// 创建描述：
//
// 修改标识：吴来伟2018-06-11 14:02
// 修改描述：
//  ------------------------------------------------------------------------------

using Newtonsoft.Json;
using System;

namespace WorkData.Code.JwtSecurityTokens
{
    public class WorkDataJwtPayload
    {
        /// <summary>
        /// 发行者（iss）
        /// </summary>
        [JsonProperty("iss")]
        public string Issuer { get; set; }

        /// <summary>
        /// 过期时间（exp）
        /// </summary>
        [JsonProperty("exp")]
        public DateTime ExpirationTime { get; set; }

        /// <summary>
        /// 主题（sub）
        /// </summary>
        [JsonProperty("sub")]
        public string Subject { get; set; }

        /// <summary>
        /// 听众（aud）
        /// </summary>
        [JsonProperty("aud")]
        public string Audience { get; set; }
    }
}