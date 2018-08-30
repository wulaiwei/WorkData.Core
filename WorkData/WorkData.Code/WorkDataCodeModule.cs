using Autofac;
using WorkData.Code.Repositories;
using WorkData.Code.Repositories.Predicates;
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

            builder.RegisterType<UnitOfWorkManager>()
                .As<IUnitOfWorkManager>();

            builder.RegisterGeneric(typeof(WorkDataPredicate<>))
                .As(typeof(IPredicate<>));

            builder.RegisterGeneric(typeof(PredicateGroup<>))
                .As(typeof(IPredicateGroup<>));

            builder.RegisterGeneric(typeof(BaseRepository<,>))
                .As(typeof(IBaseRepository<,>));

            builder.RegisterType<UnitOfWorkManager>()
                .As<IUnitOfWorkManager>();

            builder.RegisterType<ClaimsSession>()
                .As<IWorkDataSession>();
        }
    }
}