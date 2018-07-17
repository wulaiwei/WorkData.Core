// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：WorkDataClaimsType.cs
// 创建标识：吴来伟 2017-12-19 15:22
// 创建描述：
//
// 修改标识：吴来伟2017-12-19 15:22
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Security.Claims;

namespace WorkData.Code.WorkDataIdentity.Claims
{
    /// <summary>
    /// WorkDataClaimsType
    /// </summary>
    public class WorkDataClaimsType
    {
        /// <summary>
        /// UserId.
        /// </summary>
        public static string UserId { get; set; } = ClaimTypes.NameIdentifier;
    }
}