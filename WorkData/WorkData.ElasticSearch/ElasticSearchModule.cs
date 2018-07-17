using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using WorkData.ElasticSearch.Impl;
using WorkData.ElasticSearch.Interfaces;
using WorkData.ElasticSearch.Setting;
using WorkData.Extensions.Modules;
using WorkData.Util.Common.Interceptors;

namespace WorkData.ElasticSearch
{
    public class ElasticSearchModule : WorkDataBaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(t => new WorkDataBaseInterceptor())
                .Named<IInterceptor>
                ("ElasticSearchInterceptor")
                .InstancePerLifetimeScope();

            builder.RegisterType<ElasticSearchSource>();
            builder.RegisterType<NullElasticClient>();

            builder.RegisterType<ElasticsearchProvider>()
                .As(typeof(IDeleteProvider),typeof(ISearchProvider),typeof(IIndexProvider),typeof(IAliasProvider),typeof(IUpdateProvider))
                .EnableInterfaceInterceptors();
        }
    }
}