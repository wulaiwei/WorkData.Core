using Autofac;
using WorkData.Extensions.Modules;
using WorkDataEs.WorkDataElasticSearchs.Contents;

namespace WorkDataEs
{
    /// <summary>
    /// BaseUnitModule
    /// </summary>
    public class BaseUnitModule : WorkDataBaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContentService>()
                .As<IContentService>().InstancePerLifetimeScope();
        }
    }
}