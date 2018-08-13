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
        public ClaimsPrincipal Principal;

        public ClaimsSession(IPrincipal principal)
        {
            Principal = principal as ClaimsPrincipal;
        }

        /// <summary>
        ///     UserId
        /// </summary>
        public override string UserId => Principal.GetClaimValue(WorkDataClaimsType.UserId);

    }
}