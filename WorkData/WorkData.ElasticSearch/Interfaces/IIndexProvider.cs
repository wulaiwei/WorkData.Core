// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：Cloud.Util.Elasticsearch
// 文件名：IIndexProvider.cs
// 创建标识：吴来伟 2018-01-10 15:02
// 创建描述：
//
// 修改标识：吴来伟2018-01-10 15:07
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Collections.Generic;

namespace WorkData.ElasticSearch.Interfaces
{
    /// <summary>
    ///     IIndexProvider
    /// </summary>
    public interface IIndexProvider
    {
        /// <summary>
        ///     index是否存在
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        bool IndexExists(string index);

        /// <summary>
        ///     创建index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="index"></param>
        void Index<T>(T entity, string index) where T : class;

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="index"></param>
        void BulkIndex<T>(List<T> entity, string index) where T : class;

        /// <summary>
        /// 删除index
        /// </summary>
        /// <param name="index"></param>
        void RemoveIndex(string index);
    }
}