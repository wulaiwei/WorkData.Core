// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Infrastructure
// 文件名：IBaseRepository.cs
// 创建标识：吴来伟 2017-12-06 18:17
// 创建描述：
//
// 修改标识：吴来伟2018-02-12 10:44
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Insert(IEnumerable<TEntity> entities);

        /// <summary>
        ///     GetAll
        /// </summary>
        /// <returns>IQueryable to be used to select entities from database</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// FindBy
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        TEntity FindBy(TPrimaryKey primaryKey);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Update(IEnumerable<TEntity> entities);
    }
}