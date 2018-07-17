// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：ClaimsSession.cs
// 创建标识：吴来伟 2017-12-19 15:16
// 创建描述：
//
// 修改标识：吴来伟2017-12-19 16:58
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Security.Claims;
using System.Security.Principal;
using WorkData.Code.WorkDataIdentity.Claims;

#endregion

namespace WorkData.Code.Sessions
{
    /// <summary>
    ///     ClaimsSession
    /// </summary>
    public class ClaimsSession : WorkDataBaseSession
    {
        private readonly ClaimsPrincipal _principal;

        public ClaimsSession(IPrincipal principal)
        {
            _principal = principal as ClaimsPrincipal;
        }

        /// <summary>
        ///     UserId
        /// </summary>
        public override string UserId => GetClaimValue(WorkDataClaimsType.UserId);

        /// <summary>
        ///     获取申明值
        /// </summary>
        /// <returns></returns>
        public string GetClaimValue(string claimType)
        {
            var claim = _principal?.FindFirst(c => c.Type == claimType);

            return string.IsNullOrEmpty(claim?.Value) ? null : claim.Value;
        }
    }
}