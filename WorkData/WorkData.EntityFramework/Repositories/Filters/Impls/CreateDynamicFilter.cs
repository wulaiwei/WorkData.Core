using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WorkData.Code.Entities.BaseInterfaces;
using WorkData.Code.Sessions;
using WorkData.Dependency;
using WorkData.EntityFramework.Repositories.Filters;
using Z.EntityFramework.Plus;
using WorkData.EntityFramework.Repositories.Filters.Configs;

namespace WorkData.EntityFramework.Repositories.Filters.Impls
{
    /// <summary>
    /// CreateDynamicFilter
    /// </summary>
    [DynamicFilter(Name = "CreateUserId")]
    public class CreateDynamicFilter : IDynamicFilter
    {
        /// <summary>
        /// InitFilter
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public BaseQueryFilter InitFilter(DbContext dbContext)
        {
            var workdataSession = IocManager.Instance.Resolve<IWorkDataSession>();
            if (workdataSession == null)
                return dbContext
                    .Filter<ICreate>("CreateUserId", x => x.Where(w => w.CreateUserId == string.Empty ));

            return dbContext
                .Filter<ICreate>("CreateUserId", x => x.Where(w => w.CreateUserId == workdataSession.UserId || w.CreateUserId == ""));
        }
    }
}
