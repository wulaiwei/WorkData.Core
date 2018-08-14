#region

using Autofac;
using AutoMapper;
using WorkData.Code.Extensions;
using WorkData.Extensions.Modules;

#endregion

namespace WorkData.Service
{
    /// <summary>
    ///     WorkDataServiceModule
    /// </summary>
    public class WorkDataServiceModule : WorkDataBaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => new MapperConfiguration(cfg =>
             {
                 cfg.AddProfiles(GetType().Assembly);
             })).SingleInstance();
        }

    }
}