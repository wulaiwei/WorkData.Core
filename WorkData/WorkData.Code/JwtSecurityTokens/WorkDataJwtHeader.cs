// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：WorkDataJwtHeader.cs
// 创建标识：吴来伟 2018-06-11 13:57
// 创建描述：
//
// 修改标识：吴来伟2018-06-11 13:57
// 修改描述：
//  ------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace WorkData.Code.JwtSecurityTokens
{
    public class WorkDataJwtHeader
    {
        /// <summary>
        /// Alg
        /// </summary>
        [JsonProperty("alg")]
        public string Alg { get; set; } = "HS256";

        /// <summary>
        /// Typ
        /// </summary>
        [JsonProperty("typ")]
        public string Typ { get; set; } = "JWT";
    }
}