﻿using System.Security.Claims;
using System.Security.Principal;
using WorkData.Code.Sessions;
using WorkData.Dependency;

namespace WorkData.Code.Service
{
    public class WorkDataBaseService
    {
        /// <summary>
        ///     WorkDataSession
        /// </summary>
        public IWorkDataSession WorkDataSession { get; set; }

        /// <summary>
        /// ClaimsPrincipal
        /// </summary>
        public ClaimsPrincipal ClaimsPrincipal { get; set; }

        public WorkDataBaseService()
        {
            WorkDataSession = IocManager.ServiceLocatorCurrent.GetInstance<IWorkDataSession>();
            ClaimsPrincipal = IocManager.ServiceLocatorCurrent.GetInstance<IPrincipal>() as ClaimsPrincipal;
        }
    }
}