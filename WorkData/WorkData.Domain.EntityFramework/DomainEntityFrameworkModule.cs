// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Domain.EntityFramework
// 文件名：DomainEntityFrameworkModule.cs
// 创建标识：吴来伟 2018-06-07 15:36
// 创建描述：
//
// 修改标识：吴来伟2018-06-08 14:41
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Autofac;
using Microsoft.EntityFrameworkCore;
using WorkData.Code.Sessions;
using WorkData.Domain.EntityFramework.EntityFramework.Contexts;
using WorkData.Domain.EntityFramework.EntityFramework.Sessions;
using WorkData.Extensions.Modules;

#endregion

namespace WorkData.Domain.EntityFramework
{
    public class DomainEntityFrameworkModule : WorkDataBaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WorkDataSessionExtension>()
                .As<IWorkDataSessionExtension>();

            builder.Register(c => new WorkDataContext(c.Resolve<DbContextOptions>())
            {
                WorkDataSession = c.Resolve<IWorkDataSession>()
            });
        }
    }
}