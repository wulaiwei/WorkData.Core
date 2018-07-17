// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.EntityFramework
// 文件名：AuditableConfigs.cs
// 创建标识：吴来伟 2017-12-21 15:40
// 创建描述：
//
// 修改标识：吴来伟2017-12-21 15:40
// 修改描述：
//  ------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WorkData.Code.Entities.BaseInterfaces;
using WorkData.Dependency;
using WorkData.Extensions.Types;

namespace WorkData.EntityFramework.Auditables
{
    public class AuditableConfigs
    {
        /// <summary>
        /// InitializedAuditables
        /// </summary>
        public static Dictionary<EntityState, List<IAuditable>> AuditableDictionary { get; set; } =
            new Dictionary<EntityState, List<IAuditable>>();

        public List<Auditable> Auditables { get; set; }

        private readonly ILoadType _loadType;

        public AuditableConfigs(ILoadType loadType)
        {
            _loadType = loadType;
        }

        /// <summary>
        /// InitializedAuditables
        /// </summary>
        /// <param name="isReload"></param>
        public virtual void InitializedAuditables(bool isReload = false)
        {
            if (AuditableDictionary != null && AuditableDictionary.Any())
                return;
            if (Auditables == null || isReload)
            {
                Auditables = new List<Auditable>();
            }
            var types = _loadType.GetAll(x => x.IsPublic && x.IsClass
                                              && typeof(IAuditable).IsAssignableFrom(x));

            foreach (var type in types)
            {
                var item = (AuditAttribute)type.GetCustomAttributes(typeof(AuditAttribute), true).FirstOrDefault();
                if (item == null)
                    continue;
                var auditable = new Auditable
                {
                    EntityState = item.EntityState,
                    AuditableImpl = IocManager.Instance.ResolveName<IAuditable>(type.FullName)
                };
                Auditables.Add(auditable);
            }

            var addAuditables = Auditables.Where(x => x.EntityState == EntityState.Added).
                Select(x => x.AuditableImpl).ToList();
            if (addAuditables.Any())
            {
                AuditableDictionary?.Add(EntityState.Added, addAuditables);
            }

            var updateAuditables = Auditables.Where(x => x.EntityState == EntityState.Modified).
                Select(x => x.AuditableImpl).ToList();
            if (updateAuditables.Any())
            {
                AuditableDictionary?.Add(EntityState.Modified, updateAuditables);
            }

            var deleteAuditables = Auditables.Where(x => x.EntityState == EntityState.Deleted).
                Select(x => x.AuditableImpl).ToList();
            if (deleteAuditables.Any())
            {
                AuditableDictionary?.Add(EntityState.Deleted, deleteAuditables);
            }
        }
    }

    public class Auditable
    {
        public EntityState EntityState { get; set; }
        public IAuditable AuditableImpl { get; set; }
    }
}