// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：WorkDataBaseJwt.cs
// 创建标识：吴来伟 2018-06-11 14:19
// 创建描述：
//
// 修改标识：吴来伟2018-06-11 14:19
// 修改描述：
//  ------------------------------------------------------------------------------
using Newtonsoft.Json;

namespace WorkData.Code.JwtSecurityTokens
{
    public class WorkDataBaseJwt
    {
        /// <summary>
        /// 私钥
        /// </summary>
        [JsonProperty("secretKey")]
        public string SecretKey { get; set; }

        /// <summary>
        /// Token颁发机构
        /// </summary>
        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        [JsonProperty("audience")]
        public string Audience { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public int Expires { get; set; }

        public WorkDataJwtHeader WorkDataJwtHeader { get; set; } = new WorkDataJwtHeader();

        public WorkDataJwtPayload WorkDataJwtPayload { get; set; } = new WorkDataJwtPayload();
    }
}