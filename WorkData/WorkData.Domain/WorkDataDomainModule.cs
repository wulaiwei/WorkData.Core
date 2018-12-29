#region

using Autofac;
using System;
using System.Linq;
using WorkData.Extensions.Modules;

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