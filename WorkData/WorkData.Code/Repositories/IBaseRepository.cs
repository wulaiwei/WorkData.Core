#region

using System.Collections.Generic;
using System.Linq;
using WorkData.Code.Entities;

#endregion

namespace WorkData.Code.Repositories
{
    /// <summary>
    ///     IBaseRepository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IBaseRepository<TEntity, TPrimaryKey>
        where TEntity : class, IAggregateRoot, IEntity<TPrimaryKey>
    {
        /// <summary>
        ///     Insert
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        TEntity Insert(TEntity model);

        /// <summary>
        ///     InsertGetId
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TPrimaryKey InsertGetId(TEntity model);

        /// <summary>
        ///     Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Insert(IEnumerable<TEntity> entities);

        /// <summary>
        ///     GetAll
        /// </summary>
        /// <returns>IQueryable to be used to select entities from database</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        ///     GetAll
        /// </summary>
        /// <returns>IQueryable to be used to select entities from database</returns>
        IQueryable<TEntity> GetAll(string[] includeNames);

        /// <summary>
        ///     GetAll
        /// </summary>
        /// <returns>IQueryable to be used to select entities from database</returns>
        IQueryable<TEntity> GetAll(params object[] filterStrings);

        /// <summary>
        ///     GetAll
        /// </summary>
        /// <returns>IQueryable to be used to select entities from database</returns>
        IQueryable<TEntity> GetAll(string[] includeNames, params object[] filterStrings);

        /// <summary>
        ///     AsNoFilterGetAll
        /// </summary>
        /// <returns>IQueryable to be used to select entities from database</returns>
        IQueryable<TEntity> AsNoFilterGetAll();

        /// <summary>
        ///     includeNames
        /// </summary>
        /// <param name="includeNames"></param>
        /// <returns>IQueryable to be used to select entities from database</returns>
        IQueryable<TEntity> AsNoFilterGetAll(string[] includeNames);

        /// <summary>
        ///     FindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns>TEntity</returns>
        TEntity FindBy(TPrimaryKey primaryKey);

        /// <summary>
        ///     FindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="includeNames"></param>
        /// <returns></returns>
        TEntity FindBy(TPrimaryKey primaryKey, string[] includeNames);

        /// <summary>
        ///     AsNoFilterFindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        TEntity AsNoFilterFindBy(TPrimaryKey primaryKey);

        /// <summary>
        ///     AsNoFilterFindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="includeNames"></param>
        /// <returns></returns>
        TEntity AsNoFilterFindBy(TPrimaryKey primaryKey, string[] includeNames);


        /// <summary>
        ///     FindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="filterStrings"></param>
        /// <returns></returns>
        TEntity FindBy(TPrimaryKey primaryKey, params object[] filterStrings);

        /// <summary>
        ///     FindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="includeNames"></param>
        /// <param name="filterStrings"></param>
        /// <returns></returns>
        TEntity FindBy(TPrimaryKey primaryKey, string[] includeNames, params object[] filterStrings);

        /// <summary>
        ///     Delete
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        ///     Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Delete(IEnumerable<TEntity> entities);

        /// <summary>
        ///     Update
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        ///     Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Update(IEnumerable<TEntity> entities);
    }
}