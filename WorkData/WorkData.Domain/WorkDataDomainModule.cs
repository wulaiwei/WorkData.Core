#region

using Autofac;
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
        }
    }
}