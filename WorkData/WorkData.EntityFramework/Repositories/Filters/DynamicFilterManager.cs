using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WorkData.Dependency;
using WorkData.EntityFramework.Repositories.Filters.Configs;
using Z.EntityFramework.Plus;

namespace WorkData.EntityFramework.Repositories.Filters
{
    public static class DynamicFilterManager
    {
        static DynamicFilterManager()
        {
            CacheGenericDynamicFilter = new Dictionary<string, IDynamicFilter>();
        }

        /// <summary>
        ///     CacheGenericDynamicFilter
        /// </summary>
        public static Dictionary<string, IDynamicFilter> CacheGenericDynamicFilter { get; set; }

        /// <summary>
        ///     AddDynamicFilter
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public static void AddDynamicFilter(this DbContext dbContext)
        {
            if (dbContext == null) return;
            foreach (var dynamicFilter in CacheGenericDynamicFilter) dynamicFilter.Value.InitFilter(dbContext);
        }

        /// <summary>
        ///     AsWorkDataNoFilter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="context"></param>
        /// <param name="filterStrings"></param>
        /// <returns></returns>
        public static IQueryable<T> AsWorkDataNoFilter<T>(this DbSet<T> query, DbContext context,
            params object[] filterStrings) where T : class
        {
            var asNoFilterQueryable = query.AsNoFilter();

            object query1 = asNoFilterQueryable;
            var items = CacheGenericDynamicFilter.Where(x => filterStrings.Contains(x.Key));

            query1 = items.Select(key => context.Filter(key.Key)).Where(item => item != null)
                .Aggregate(query1, (current, item) => (IQueryable) item.ApplyFilter<T>(current));
            return (IQueryable<T>) query1;
        }

        /// <summary>
        ///     SetCacheGenericDynamicFilter
        /// </summary>
        public static void SetCacheGenericDynamicFilter()
        {
            var dynamicFilterConfig = IocManager.Instance.ResolveServiceValue<DynamicFilterConfig>();

            foreach (var item in dynamicFilterConfig.DynamicFilterList)
            {
                var dynamicFilter = IocManager.Instance.ResolveName<IDynamicFilter>(item);
                CacheGenericDynamicFilter.Add(item, dynamicFilter);
            }
        }
    }
}