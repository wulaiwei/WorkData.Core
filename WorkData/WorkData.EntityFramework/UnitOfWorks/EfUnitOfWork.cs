// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.EntityFramework
// 文件名：EfUnitOfWork.cs
// 创建标识：吴来伟 2017-11-27 11:33
// 创建描述：
//
// 修改标识：吴来伟2017-12-04 15:46
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using WorkData.Code.UnitOfWorks;
using WorkData.Util.Common.ExceptionExtensions;

#endregion

namespace WorkData.EntityFramework.UnitOfWorks
{
    public class EfUnitOfWork : UnitOfWorkBase
    {
        /// <summary>
        ///     数据库上下文集合
        /// </summary>
        public Dictionary<string, DbContext> InitializedDbContexts;

        /// <summary>
        /// DbContextTransactions
        /// </summary>
        private readonly Dictionary<DbContext, IDbContextTransaction> _transactions;

        private readonly IEfContextFactory _efContextFactory;

        public EfUnitOfWork(IEfContextFactory efContextFactory)
        {
            _efContextFactory = efContextFactory;
            InitializedDbContexts = new Dictionary<string, DbContext>();

            _transactions = new Dictionary<DbContext, IDbContextTransaction>();
        }

        /// <summary>
        /// GetOrCreateDbContext
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <returns></returns>
        public virtual TDbContext GetOrCreateDbContext<TDbContext>()
            where TDbContext : DbContext
        {
            return _efContextFactory
                .GetCurrentDbContext<TDbContext>(InitializedDbContexts, _transactions);
        }

        /// <summary>
        /// GetOrCreateDbContext
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="conString"></param>
        /// <returns></returns>
        public virtual TDbContext GetOrCreateDbContext<TDbContext>(string conString)
            where TDbContext : DbContext
        {
            return _efContextFactory
                .GetCurrentDbContext<TDbContext>(InitializedDbContexts, _transactions, conString);
        }

        /// <summary>
        ///     ComplateUnit
        /// </summary>
        protected override void ComplateUnit()
        {
            SaveChanges();
        }

        /// <summary>
        ///     ComplateUnitAsync
        /// </summary>
        /// <returns></returns>
        protected override async Task ComplateUnitAsync()
        {
            await SaveChangesAsync();
        }

        /// <summary>
        ///     DisposeUnit
        /// </summary>
        protected override void DisposeUnit()
        {
            foreach (var item in GetAllInitializedDbContexts())
            {
                Release(item);
            }
        }

        /// <summary>
        ///     Release
        /// </summary>
        /// <param name="item"></param>
        public void Release(DbContext item)
        {
            item.Dispose();
        }

        /// <summary>
        ///     SaveChanges
        /// </summary>
        public override void SaveChanges()
        {
            foreach (var item in GetAllInitializedDbContexts())
            {
                try
                {
                    SaveChangesInDbContext(item);
                    var tran = GetValueOrDefault(_transactions, item);
                    if (tran == null) continue;
                    tran.Commit();
                    tran.Dispose();
                }
                catch (Exception ex)
                {
                    throw new UserFriendlyException(ex.Message);
                }
            }

            //清除所有事务
            _transactions.Clear();
        }

        /// <summary>
        ///     SaveChangesAsync
        /// </summary>
        /// <returns></returns>
        public override async Task SaveChangesAsync()
        {
            foreach (var item in GetAllInitializedDbContexts())
            {
                try
                {
                    await SaveChangesInDbContextAsync(item);
                    var tran = GetValueOrDefault(_transactions, item);
                    if (tran == null) continue;
                    tran.Commit();
                    tran.Dispose();
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            //清除所有事务
            _transactions.Clear();
        }

        /// <summary>
        ///     GetAllInitializedDbContexts
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<DbContext> GetAllInitializedDbContexts()
        {
            return InitializedDbContexts.Values.ToImmutableList();
        }

        /// <summary>
        ///     SaveChangesInDbContext
        /// </summary>
        /// <param name="dbContext"></param>
        protected virtual void SaveChangesInDbContext(DbContext dbContext)
        {
            dbContext.SaveChanges();
        }

        /// <summary>
        ///     SaveChangesInDbContextAsync
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        protected virtual async Task SaveChangesInDbContextAsync(DbContext dbContext)
        {
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Returns the value associated with the specified key or the default
        /// value for the TValue  type.
        /// </summary>
        private static TValue GetValueOrDefault<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.TryGetValue(key, out var value) ? value : default(TValue);
        }
    }
}