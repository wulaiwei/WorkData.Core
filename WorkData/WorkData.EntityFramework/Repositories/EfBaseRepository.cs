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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WorkData.Code.Entities;
using WorkData.Code.Repositories;
using WorkData.Code.Repositories.Predicates;
using WorkData.EntityFramework.Repositories.Filters;
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
        BaseRepository<TEntity, TPrimaryKey>,
        IRepositoryDbConntext where TEntity : class, IAggregateRoot, IEntity<TPrimaryKey>
        where TDbContext : DbContext
    {
        private readonly IDbContextProvider<TDbContext> _dbContextProvider;
        public sealed override IPredicateGroup<TEntity> PredicateGroup { get; set; }

        public EfBaseRepository(
            IDbContextProvider<TDbContext> dbContextProvider,
            IPredicateGroup<TEntity> predicateGroup)
        {
            _dbContextProvider = dbContextProvider;
            PredicateGroup = predicateGroup;
        }

        /// <summary>
        ///     Gets EF DbContext object.
        /// </summary>
        public TDbContext Context => _dbContextProvider.GetContent();

        /// <summary>
        ///     Gets DbSet for given entity.
        /// </summary>
        public virtual DbSet<TEntity> DbSet => Context.Set<TEntity>();

        #region DbContext

        /// <summary>
        ///     GetDbContext
        /// </summary>
        /// <returns></returns>
        public DbContext GetDbContext()
        {
            return Context;
        }

        #endregion

        #region Query



        /// <summary>
        ///     FindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public override TEntity FindBy(TPrimaryKey primaryKey)
        {
            var entity = DbSet.Find(primaryKey);
            return entity;
        }

        /// <summary>
        /// FindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="includeNames"></param>
        /// <returns></returns>
        public override TEntity FindBy(TPrimaryKey primaryKey, string[] includeNames)
        {
            var query = DbSet;
            foreach (var includeName in includeNames)
            {
                query.Include(includeName);
            }
            var entity = query.Find(primaryKey);
            return entity;
        }

        /// <summary>
        ///     AsNoFilterFindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public override TEntity AsNoFilterFindBy(TPrimaryKey primaryKey)
        {
            var entity = DbSet.AsNoFilter()
                .SingleOrDefault(x => x.Id.Equals(primaryKey));
            return entity;
        }

        /// <summary>
        /// AsNoFilterFindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="includeNames"></param>
        /// <returns></returns>
        public override TEntity AsNoFilterFindBy(TPrimaryKey primaryKey, string[] includeNames)
        {

            var query = DbSet.AsNoFilter();
            foreach (var includeName in includeNames)
            {
                query.Include(includeName);
            }
            var entity = query.SingleOrDefault(x => x.Id.Equals(primaryKey));

            return entity;
        }


        /// <summary>
        ///     FindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="filterStrings"></param>
        /// <returns></returns>
        public override TEntity FindBy(TPrimaryKey primaryKey, params object[] filterStrings)
        {
            var entity = DbSet.AsWorkDataNoFilter(Context, filterStrings)
                .SingleOrDefault(x => x.Id.Equals(primaryKey));
            return entity;
        }

        /// <summary>
        /// FindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="includeNames"></param>
        /// <param name="filterStrings"></param>
        /// <returns></returns>
        public override TEntity FindBy(TPrimaryKey primaryKey, string[] includeNames, params object[] filterStrings)
        {
            var query = DbSet.AsWorkDataNoFilter(Context, filterStrings);
            foreach (var includeName in includeNames)
            {
                query.Include(includeName);
            }
            var entity = query.SingleOrDefault(x => x.Id.Equals(primaryKey));

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


        /// <summary>
        /// GetAll
        /// </summary>
        /// <param name="includeNames"></param>
        /// <returns></returns>
        public override IQueryable<TEntity> GetAll(string[] includeNames)
        {
            var query = DbSet;
            foreach (var includeName in includeNames)
            {
                query.Include(includeName);
            }
            return query;
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <param name="filterStrings"></param>
        /// <returns></returns>
        public override IQueryable<TEntity> GetAll(params object[] filterStrings)
        {
            return DbSet.AsWorkDataNoFilter(Context, filterStrings);
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <param name="includeNames"></param>
        /// <param name="filterStrings"></param>
        /// <returns></returns>
        public override IQueryable<TEntity> GetAll(string[] includeNames, params object[] filterStrings)
        {
            var query = DbSet.AsWorkDataNoFilter(Context, filterStrings);

            foreach (var includeName in includeNames)
            {
                query.Include(includeName);
            }
            return query;
        }

        /// <summary>
        /// AsNoFilterGetAll
        /// </summary>
        /// <returns></returns>
        public override IQueryable<TEntity> AsNoFilterGetAll()
        {
            return DbSet.AsNoFilter();
        }

        /// <summary>
        /// AsNoFilterGetAll
        /// </summary>
        /// <param name="includeNames"></param>
        /// <returns></returns>
        public override IQueryable<TEntity> AsNoFilterGetAll(string[] includeNames)
        {
            var query = DbSet.AsNoFilter();

            foreach (var includeName in includeNames)
            {
                query.Include(includeName);
            }
            return query;
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
        ///     Insert
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
        ///     Delete
        /// </summary>
        /// <param name="entity"></param>
        public override void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            Context.SaveChanges();
        }

        /// <summary>
        ///     Delete
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
        ///     Update
        /// </summary>
        /// <param name="entity"></param>
        public override void Update(TEntity entity)
        {
            DbSet.Update(entity);
            Context.SaveChanges();
        }

        /// <summary>
        ///     Update
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
    }
}