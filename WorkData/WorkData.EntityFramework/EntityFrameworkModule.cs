// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.EntityFramework
// 文件名：EntityFrameworkModule.cs
// 创建标识：吴来伟 2017-12-06 18:17
// 创建描述：
//
// 修改标识：吴来伟2017-12-12 9:39
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Autofac;
using WorkData.Code.Entities.BaseInterfaces;
using WorkData.Code.Helpers;
using WorkData.Code.Repositories;
using WorkData.Code.UnitOfWorks;
using WorkData.EntityFramework.Auditables;
using WorkData.EntityFramework.Extensions;
using WorkData.EntityFramework.Repositories;
using WorkData.EntityFramework.UnitOfWorks;
using WorkData.Extensions.Modules;
using WorkData.Extensions.TypeFinders;

#endregion

namespace WorkData.EntityFramework
{
    /// <summary>
    ///     EntityFrameworkModule
    /// </summary>
    public class EntityFrameworkModule : WorkDataBaseModule
    {
        private readonly ITypeFinder _typeFinder;
        public EntityFrameworkModule()
        {
            _typeFinder = NullTypeFinder.Instance;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuditableConfigs>()
                .SingleInstance();

            builder.RegisterType<EfContextFactory>()
                .As<IEfContextFactory>();

            builder.RegisterGeneric(typeof(DbContentProvider<>))
                .As(typeof(IDbContextProvider<>));

            builder.RegisterType<EfUnitOfWork>()
                .As<IUnitOfWork, IActiveUnitOfWork, IUnitOfWorkCompleteHandle>();

            #region 动态审计注入
            var auditTypes = _typeFinder.FindClassesOfType<IAuditable>();

            foreach (var auditType in auditTypes)
            {
                builder.RegisterType(auditType).Named<IAuditable>(auditType.FullName);
            }
            #endregion

            #region Repository注入
            var types = _typeFinder.FindClassesOfType<WorkDataBaseDbContext>();

            foreach (var type in types)
            {
                var entityTypeInfos = DbContextHelper.GetEntityTypeInfos(type);
                foreach (var entityTypeInfo in entityTypeInfos)
                {
                    var primaryKeyType = EntityHelper.GetPrimaryKeyType(entityTypeInfo.EntityType);
                    var genericRepositoryType = typeof(IBaseRepository<,>).MakeGenericType(entityTypeInfo.EntityType, primaryKeyType);

                    var baseImplType = typeof(EfBaseRepository<,,>);
                    var implType = baseImplType.MakeGenericType(entityTypeInfo.DeclaringType, entityTypeInfo.EntityType, primaryKeyType);
                    builder.RegisterType(implType).As(genericRepositoryType);
                }
            }
            #endregion
        }
    }
}