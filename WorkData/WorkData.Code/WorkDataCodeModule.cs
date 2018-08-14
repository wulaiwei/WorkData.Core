// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：WorkDataCodeModule.cs
// 创建标识：吴来伟 2018-06-07 15:39
// 创建描述：
//
// 修改标识：吴来伟2018-06-07 15:39
// 修改描述：
//  ------------------------------------------------------------------------------

using Autofac;
using AutoMapper;
using WorkData.Code.Repositories;
using WorkData.Code.Sessions;
using WorkData.Code.UnitOfWorks;
using WorkData.Extensions.Modules;

namespace WorkData.Code
{
    public class WorkDataCodeModule : WorkDataBaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWorkInterceptor>().InstancePerLifetimeScope();

            builder.RegisterType<CurrentUnitOfWorkProvider>()
                .As<ICurrentUnitOfWorkProvider>();

            builder.RegisterGeneric(typeof(BaseRepository<,>))
                .As(typeof(IBaseRepository<,>));

            builder.RegisterType<UnitOfWorkManager>()
                .As<IUnitOfWorkManager>();

            builder.RegisterType<ClaimsSession>()
                .As<IWorkDataSession>();
        }
    }
}