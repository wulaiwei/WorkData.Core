// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Infrastructure
// 文件名：BaseRepository.cs
// 创建标识：吴来伟 2017-12-06 18:17
// 创建描述：
//
// 修改标识：吴来伟2018-02-12 10:55
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Collections.Generic;
using System.Linq;
using WorkData.Code.Entities;
using WorkData.Code.Repositories.Predicates;
using WorkData.Code.UnitOfWorks;
using WorkData.Dependency;

#endregion

namespace WorkData.Code.Repositories
{
    /// <summary>
    ///     BaseRepository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class BaseRepository<TEntity, TPrimaryKey> :
        IBaseRepository<TEntity, TPrimaryKey> where TEntity : class, IAggregateRoot, IEntity<TPrimaryKey>
    {
        /// <summary>
        ///     UnitOfWorkManager
        /// </summary>
        public IUnitOfWorkManager UnitOfWorkManager { get; set; }

        /// <summary>
        ///     IocResolver
        /// </summary>
        public IResolver IocResolver { get; set; }

        /// <summary>
        ///     Insert
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        public abstract TEntity Insert(TEntity model);

        /// <summary>
        ///     InsertGetId
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public abstract TPrimaryKey InsertGetId(TEntity model);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public abstract void Insert(IEnumerable<TEntity> entities);

        /// <summary>
        ///     GetAll
        /// </summary>
        /// <returns>IQueryable to be used to select entities from database</returns>
        public abstract IQueryable<TEntity> GetAll();

        /// <summary>
        /// GetAll
        /// </summary>
        /// <param name="includeNames"></param>
        /// <returns></returns>
        public abstract IQueryable<TEntity> GetAll(string[] includeNames);

        /// <summary>
        /// GetAll
        /// </summary>
        /// <param name="filterStrings"></param>
        /// <returns></returns>
        public abstract IQueryable<TEntity> GetAll(params object[] filterStrings);

        /// <summary>
        /// GetAll
        /// </summary>
        /// <param name="includeNames"></param>
        /// <param name="filterStrings"></param>
        /// <returns></returns>
        public abstract IQueryable<TEntity> GetAll(string[] includeNames, params object[] filterStrings);

        /// <summary>
        /// AsNoFilterGetAll
        /// </summary>
        /// <returns></returns>
        public abstract IQueryable<TEntity> AsNoFilterGetAll();

        /// <summary>
        /// AsNoFilterGetAll
        /// </summary>
        /// <param name="includeNames"></param>
        /// <returns></returns>
        public abstract IQueryable<TEntity> AsNoFilterGetAll(string[] includeNames);

        /// <summary>
        /// FindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public abstract TEntity FindBy(TPrimaryKey primaryKey);

        /// <summary>
        /// FindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="includeNames"></param>
        /// <returns></returns>
        public abstract TEntity FindBy(TPrimaryKey primaryKey, string[] includeNames);

        /// <summary>
        /// AsNoFilterFindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public abstract TEntity AsNoFilterFindBy(TPrimaryKey primaryKey);

        /// <summary>
        /// AsNoFilterFindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="includeNames"></param>
        /// <returns></returns>
        public abstract TEntity AsNoFilterFindBy(TPrimaryKey primaryKey, string[] includeNames);

        /// <summary>
        /// FindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="filterStrings"></param>
        /// <returns></returns>
        public abstract TEntity FindBy(TPrimaryKey primaryKey, params object[] filterStrings);

        /// <summary>
        /// FindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="includeNames"></param>
        /// <param name="filterStrings"></param>
        /// <returns></returns>
        public abstract TEntity FindBy(TPrimaryKey primaryKey, string[] includeNames, params object[] filterStrings);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        public abstract void Delete(TEntity entity);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public abstract void Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        public abstract void Update(TEntity entity);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public abstract void Update(IEnumerable<TEntity> entities);
    }
}