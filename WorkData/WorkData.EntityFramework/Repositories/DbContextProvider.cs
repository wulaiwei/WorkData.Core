// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Infrastructure
// 文件名：DbContentProvider.cs
// 创建标识：吴来伟 2017-12-04 21:46
// 创建描述：
//
// 修改标识：吴来伟2017-12-04 21:46
// 修改描述：
//  ------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using WorkData.Code.UnitOfWorks;
using WorkData.EntityFramework.UnitOfWorks;

namespace WorkData.EntityFramework.Repositories
{
    /// <summary>
    /// DbContentProvider
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public class DbContentProvider<TDbContext> : IDbContextProvider<TDbContext>
        where TDbContext : DbContext
    {
        /// <summary>
        /// _currentUnitOfWorkProvider
        /// </summary>
        private readonly ICurrentUnitOfWorkProvider _currentUnitOfWorkProvider;

        /// <summary>
        /// DbContentProvider
        /// </summary>
        /// <param name="currentUnitOfWorkProvider"></param>
        public DbContentProvider(ICurrentUnitOfWorkProvider currentUnitOfWorkProvider)
        {
            _currentUnitOfWorkProvider = currentUnitOfWorkProvider;
        }

        /// <summary>
        /// GetContent
        /// </summary>
        /// <returns></returns>
        public TDbContext GetContent()
        {
            if (!(_currentUnitOfWorkProvider.Current is EfUnitOfWork efUnitOfWork))
            {
                throw new System.Exception("EfUnitOfWork is null");
            }

            return efUnitOfWork.GetOrCreateDbContext<TDbContext>();
        }

        /// <summary>
        /// GetContent
        /// </summary>
        /// <returns></returns>
        public TDbContext GetContent(string conString)
        {
            if (!(_currentUnitOfWorkProvider.Current is EfUnitOfWork efUnitOfWork))
            {
                throw new System.Exception("EfUnitOfWork is null");
            }

            return efUnitOfWork.GetOrCreateDbContext<TDbContext>(conString);
        }
    }
}