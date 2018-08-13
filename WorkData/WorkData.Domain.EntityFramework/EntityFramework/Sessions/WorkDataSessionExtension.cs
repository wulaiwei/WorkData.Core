// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Domain.EntityFramework
// 文件名：WorkDataSessionExtension.cs
// 创建标识：吴来伟 2018-06-22 16:00
// 创建描述：
//
// 修改标识：吴来伟2018-06-22 16:00
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Security.Claims;
using System.Security.Principal;
using WorkData.Code.Sessions;

namespace WorkData.Domain.EntityFramework.EntityFramework.Sessions
{
    public class WorkDataSessionExtension : ClaimsSession, IWorkDataSessionExtension
    {
        public WorkDataSessionExtension(IPrincipal principal) : base(principal)
        {
        }

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName => Principal.GetClaimValue(ClaimTypes.Name);
    }
}