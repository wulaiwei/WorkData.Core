// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.EntityFramework
// 文件名：EfBaseRepository.cs
// 创建标识：吴来伟 2017-12-06 18:17
// 创建描述：
//
// 修改标识：吴来伟2018-02-12 10:22
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkData.Code.Entities;
using WorkData.Code.Repositories;

#endregion

namespace WorkData.EntityFramework.Repositories
{
    /// <summary>
    ///     EfBaseRepository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <typeparam name="TDbContext"></typeparam>
    public class EfBaseRepository<TDbContext, TEntity, TPrimaryKey> :
        BaseRepository<TEntity, TPrimaryKey>, IRepositoryDbConntext where TEntity : class, IAggregateRoot, IEntity<TPrimaryKey>
        where TDbContext : DbContext
    {
        /// <summary>
        ///     Gets EF DbContext object.
        /// </summary>
        public virtual TDbContext Context => _dbContextProvider.GetContent();

        /// <summary>
        ///     Gets DbSet for given entity.
        /// </summary>
        public virtual DbSet<TEntity> DbSet => Context.Set<TEntity>();

        private readonly IDbContextProvider<TDbContext> _dbContextProvider;

        public EfBaseRepository(IDbContextProvider<TDbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        #region Query

        /// <summary>
        /// FindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public override TEntity FindBy(TPrimaryKey primaryKey)
        {
            var entity = DbSet.Find(primaryKey);
            return entity;
        }

        /// <summary>
        ///     GetAll
        /// </summary>
        /// <returns></returns>
        public override IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        #endregion

        #region Insert

        /// <summary>
        ///     Insert
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        public override TEntity Insert(TEntity model)
        {
            return DbSet.Add(model).Entity;
        }

        /// <summary>
        ///     InsertGetId
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override TPrimaryKey InsertGetId(TEntity model)
        {
            model = Insert(model);

            Context.SaveChanges();

            return model.Id;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entities"></param>
        public override void Insert(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            DbSet.AddRange(entities);

            Context.SaveChanges();
        }

        #endregion

        #region Delete

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        public override void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            Context.SaveChanges();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entities"></param>
        public override void Delete(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            DbSet.RemoveRange(entities);

            Context.SaveChanges();
        }

        #endregion

        #region Update

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        public override void Update(TEntity entity)
        {
            DbSet.Update(entity);
            Context.SaveChanges();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entities"></param>
        public override void Update(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            DbSet.UpdateRange(entities);

            Context.SaveChanges();
        }

        #endregion

        /// <summary>
        /// GetDbContext
        /// </summary>
        /// <returns></returns>
        public DbContext GetDbContext()
        {
            return Context;
        }
    }
}