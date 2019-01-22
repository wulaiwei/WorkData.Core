#region

using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;
using WorkData.Code.Sessions;
using WorkData.Dependency;

#endregion

namespace WorkData.BaseWeb.Infrastructure
{
    public class WorkDataBaseController : Controller
    {

        /// <summary>
        /// WorkDataSession
        /// </summary>s
        public IWorkDataSession WorkDataSession { get; set; } =
            IocManager.ServiceLocatorCurrent.GetInstance<IWorkDataSession>();

        private IPrincipal Principal { get; set; } 

        /// <summary>
        /// ClaimsPrincipal
        /// </summary>s
        public ClaimsPrincipal ClaimsPrincipal { get; set; } =
            IocManager.ServiceLocatorCurrent.GetInstance<IPrincipal>() as ClaimsPrincipal;
    }
}