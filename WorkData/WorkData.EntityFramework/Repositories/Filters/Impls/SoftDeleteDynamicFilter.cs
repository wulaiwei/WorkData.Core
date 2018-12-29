using Microsoft.EntityFrameworkCore;
using System.Linq;
using WorkData.Code.Entities;
using WorkData.EntityFramework.Repositories.Filters.Configs;
using Z.EntityFramework.Plus;

namespace WorkData.EntityFramework.Repositories.Filters.Impls
{
    /// <summary>
    /// SoftDeleteDynamicFilter
    /// </summary>
    [DynamicFilter(Name = "SoftDelete")]
    public class SoftDeleteDynamicFilter : IDynamicFilter
    {
        public BaseQueryFilter InitFilter(DbContext dbContext)
        {
            return dbContext
                .Filter<IsSoftDelete>("SoftDelete", x => x.Where(w => !w.IsDelete));
        }
    }
}