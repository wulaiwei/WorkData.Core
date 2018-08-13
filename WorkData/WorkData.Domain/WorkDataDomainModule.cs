#region

using System;
using System.Linq;
using Autofac;
using WorkData.Extensions.Modules;
using WorkData.Extensions.TypeFinders;

#endregion

namespace WorkData.Domain
{
    /// <summary>
    ///     WorkDataServiceModule
    /// </summary>
    public class WorkDataDomainModule : WorkDataBaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblys = AppDomain.CurrentDomain.GetAssemblies().ToList();

            builder.RegisterAssemblyTypes(assemblys.ToArray())
                .Where(t => t.Name.EndsWith("Manage"))
                .AsSelf();

        }
    }
}