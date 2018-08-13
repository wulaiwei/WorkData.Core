using System.Security.Claims;
using System.Security.Principal;
using WorkData.Code.Sessions;
using WorkData.Dependency;

namespace WorkData.Code.Domain
{
    public class WorkDataBaseManage: IWorkDataBaseManage
    {
        /// <summary>
        ///     WorkDataSession
        /// </summary>
        public IWorkDataSession WorkDataSession { get; set; }

        /// <summary>
        /// ClaimsPrincipal
        /// </summary>
        public ClaimsPrincipal ClaimsPrincipal { get; set; }

        public WorkDataBaseManage()
        {
            WorkDataSession = IocManager.Instance.Resolve<IWorkDataSession>();
            ClaimsPrincipal = IocManager.Instance.Resolve<IPrincipal>() as ClaimsPrincipal;
        }
    }
}