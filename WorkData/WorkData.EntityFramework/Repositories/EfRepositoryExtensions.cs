// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.EntityFramework
// 文件名：EfRepositoryExtensions.cs
// 创建标识：吴来伟 2018-02-12 10:26
// 创建描述：
//
// 修改标识：吴来伟2018-02-12 10:26
// 修改描述：
//  ------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using System;
using WorkData.Code.Entities;
using WorkData.Code.Repositories;

namespace WorkData.EntityFramework.Repositories
{
    /// <summary>
    /// EfRepositoryExtensions
    /// </summary>
    public static class EfRepositoryExtensions
    {
        public static DbContext GetDbContext<TEntity, TPrimaryKey>(this IBaseRepository<TEntity, TPrimaryKey> repository)
            where TEntity : class, IAggregateRoot, IEntity<TPrimaryKey>
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (!(repository is IRepositoryDbConntext repositoryWithDbContext))
            {
                throw new ArgumentException("Given repository does not implement IRepositoryWithDbContext", nameof(repository));
            }

            return repositoryWithDbContext.GetDbContext();
        }
    }
}