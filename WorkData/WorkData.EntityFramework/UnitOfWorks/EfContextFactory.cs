// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.EntityFramework
// 文件名：EfContextFactory.cs
// 创建标识：吴来伟 2017-12-05 9:15
// 创建描述：
//
// 修改标识：吴来伟2017-12-05 10:13
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using WorkData.Dependency;
using WorkData.EntityFramework.Repositories.Filters;

#endregion

namespace WorkData.EntityFramework.UnitOfWorks
{
    /// <summary>
    ///     EfContextFactory
    /// </summary>
    public class EfContextFactory : IEfContextFactory
    {
        /// <summary>
        ///     default current context
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="tranDic"></param>
        /// <returns></returns>
        public TDbContext GetCurrentDbContext<TDbContext>(Dictionary<string, DbContext> dic, Dictionary<DbContext, IDbContextTransaction> tranDic)
            where TDbContext : DbContext
        {
            return GetCurrentDbContext<TDbContext>(dic, tranDic, string.Empty);
        }

        /// <summary>
        ///GetCurrentDbContext
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="dic"></param>
        /// <param name="tranDic"></param>
        /// <param name="conString"></param>
        /// <returns></returns>
        public TDbContext GetCurrentDbContext<TDbContext>(Dictionary<string, DbContext> dic, Dictionary<DbContext, IDbContextTransaction> tranDic, string conString)
            where TDbContext : DbContext
        {
            conString = typeof(TDbContext).ToString();
            var dbContext = dic.ContainsKey(conString + "DbContext") ? dic[conString + "DbContext"] : null;
            try
            {
                if (dbContext != null)
                {
                    return (TDbContext)dbContext;
                }
            }
            catch (Exception)
            {
                dic.Remove(conString + "DbContext");
            }
            dbContext = IocManager.ServiceLocatorCurrent.GetInstance<TDbContext>();

            //初始化拦截器
            dbContext.AddDynamicFilter();

            //我们在创建一个，放到数据槽中去
            dic.Add(conString + "DbContext", dbContext);

            //开始事务
            var tran = dbContext.Database.BeginTransaction();
            tranDic.Add(dbContext, tran);

            return (TDbContext)dbContext;
        }
    }
}