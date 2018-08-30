using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace WorkData.EntityFramework.Repositories.Filters
{
    public interface IDynamicFilter
    {
        BaseQueryFilter InitFilter(DbContext dbContext);
    }
}