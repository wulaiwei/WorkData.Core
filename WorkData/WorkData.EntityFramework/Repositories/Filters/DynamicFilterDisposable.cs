using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace WorkData.EntityFramework.Repositories.Filters
{
    public class DynamicFilterDisposable : IDisposable
    {
        public bool IsRollBack { get; set; }
        public DbContext DbContext { get; set; }

        public DynamicFilterDisposable(DbContext dbContext, bool isRollBack = true, params object[] filterStrings)
        {
            DbContext = dbContext;
            IsRollBack = isRollBack;
            if (DbContext == null) return;
            var keys = DynamicFilterManager.CacheGenericDynamicFilter.Keys.Where(x => !filterStrings.Contains(x)).ToList();
            foreach (var itemFilterString in keys)
            {
                DbContext.Filter(itemFilterString).Disable();
            }
        }

        public void Dispose()
        {
            if (!IsRollBack) return;
            foreach (var itemKey in DynamicFilterManager.CacheGenericDynamicFilter.Keys)
            {
                DbContext.Filter(itemKey).Enable();
            }
        }
    }
}
