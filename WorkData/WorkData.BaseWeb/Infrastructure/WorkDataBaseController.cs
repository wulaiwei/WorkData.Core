#region

using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;
using WorkData.Code.Sessions;
using WorkData.Dependency;

#endregion

namespace WorkData.BaseWeb.Infrastructure
{
    public abstract class WorkDataBaseController : Controller
    {
        public virtual IWorkDataSession WorkDataSession { get; set; }
        public virtual ClaimsPrincipal ClaimsPrincipal { get; set; }
    }
}