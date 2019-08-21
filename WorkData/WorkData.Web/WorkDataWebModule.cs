// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Web
// 文件名：WorkDataWebModule.cs
// 创建标识：吴来伟 2018-06-11 10:40
// 创建描述：
//
// 修改标识：吴来伟2018-06-11 10:40
// 修改描述：
//  ------------------------------------------------------------------------------

using Autofac;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore.Internal;
using WorkData.BaseWeb.Infrastructure;
using WorkData.Code.Sessions;
using WorkData.Domain.Permissions.Users;
using WorkData.Extensions.Modules;
using WorkData.Extensions.TypeFinders;
using WorkData.Web.ApiController;

namespace WorkData.Web
{
    public class WorkDataWebModule : WorkDataBaseModule
    {
        private readonly ITypeFinder _typeFinder;

        public WorkDataWebModule()
        {
            _typeFinder = NullTypeFinder.Instance;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var workDataBaseControllers = _typeFinder.FindClassesOfType<WorkDataBaseController>();
            if (workDataBaseControllers.Any())
            {
                foreach (var workDataBaseController in workDataBaseControllers)
                {
                    builder.RegisterType(workDataBaseController).OnActivating(x =>
                    {
                        var instance = x.Instance as WorkDataBaseController;
                        instance.WorkDataSession = x.Context.Resolve<IWorkDataSession>();
                        instance.ClaimsPrincipal = x.Context.Resolve<IPrincipal>() as ClaimsPrincipal;
                    });
                }
            }

            builder.RegisterType<SignInManager<BaseUser>>()
                .AsSelf().InstancePerRequest();
        }
    }
}