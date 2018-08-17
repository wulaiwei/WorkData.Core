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
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WorkData.Code.Entities;
using WorkData.Code.Repositories;
using WorkData.Code.Repositories.Predicates;
using WorkData.EntityFramework.Extensions;
using Z.EntityFramework.Plus;

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
        //public IQueryable<EntityType> EntityTypes => Context.Model.EntityTypes.Where(t => t.Something == true);

        private readonly IDbContextProvider<TDbContext> _dbContextProvider;
        private readonly IPredicateGroup<TEntity> _predicateGroup;

        public EfBaseRepository(
            IDbContextProvider<TDbContext> dbContextProvider,
            IPredicateGroup<TEntity> predicateGroup)
        {
            _dbContextProvider = dbContextProvider;
            _predicateGroup = predicateGroup;
        }

        #region Query

        /// <summary>
        /// FindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public override TEntity FindBy(TPrimaryKey primaryKey)
        {
            _predicateGroup.AddPredicate(true,x=>x.Id.Equals(primaryKey));

            var entity = DbSet.WhereIf(_predicateGroup)
                .FirstOrDefault();
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

        #region DbContext
        /// <summary>
        /// GetDbContext
        /// </summary>
        /// <returns></returns>
        public DbContext GetDbContext()
        {
            return Context;
        } 
        #endregion
    }
}