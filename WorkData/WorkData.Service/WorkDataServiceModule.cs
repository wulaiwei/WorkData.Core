#region

using Autofac;
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
        }
    }
}