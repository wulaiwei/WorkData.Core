#region

using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using WorkData.Code.Sessions;
using WorkData.Dependency;

#endregion

namespace WorkData.Code.Webs.Infrastructure
{
    public class WorkDataBaseController : Controller
    {
        /// <summary>
        /// WorkDataSession
        /// </summary>s
        public IWorkDataSession WorkDataSession { get; set; } =
            IocManager.Instance.Resolve<IWorkDataSession>();


        /// <summary>
        /// ClaimsPrincipal
        /// </summary>s
        public ClaimsPrincipal ClaimsPrincipal { get; set; } =
            IocManager.Instance.Resolve<IPrincipal>() as ClaimsPrincipal;
    }
}