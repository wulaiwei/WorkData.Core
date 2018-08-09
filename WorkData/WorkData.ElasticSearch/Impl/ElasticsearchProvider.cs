// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：Cloud.Util.Elasticsearch
// 文件名：ElasticsearchProvider.cs
// 创建标识：吴来伟 2018-01-10 15:02
// 创建描述：
//
// 修改标识：吴来伟2018-01-10 15:07
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Autofac.Extras.DynamicProxy;
using Nest;
using System.Collections.Generic;
using System.Linq;
using WorkData.ElasticSearch.Entity;
using WorkData.ElasticSearch.Interfaces;

#endregion

namespace WorkData.ElasticSearch.Impl
{
    /// <summary>
    ///     ElasticsearchProvider
    /// </summary>
    [Intercept("ElasticSearchInterceptor")]
    public class ElasticsearchProvider : IIndexProvider, IAliasProvider, ISearchProvider, IDeleteProvider, IUpdateProvider
    {
        #region IOC

        public ElasticClient ElasticClient { get; set; }

        /// <summary>
        ///     ElasticsearchProvider
        /// </summary>
        public ElasticsearchProvider()
        {
            ElasticClient = NullElasticClient.Instance;
        }

        #endregion

        /// <summary>
        ///     index 是否存在
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool IndexExists(string index)
        {
            var res = ElasticClient.IndexExists(index);
            return res.Exists;
        }

        /// <summary>
        ///     创建index  并新增数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public void Index<T>(T entity, string index) where T : class
        {
            if (!IndexExists(index))
            {
                ElasticClient.InitializeIndexMap<T>(index);
            }
            var response = ElasticClient.Index(entity,
                s => s.Index(index));

            if (!response.IsValid)
                throw new ElasticsearchException("新增数据失败:" + response.OriginalException.Message);
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="index"></param>
        public void BulkIndex<T>(List<T> entity, string index) where T : class
        {
            if (!IndexExists(index))
            {
                ElasticClient.InitializeIndexMap<T>(index);
            }

            var bulkRequest = new BulkRequest(index)
            {
                Operations = new List<IBulkOperation>()
            };
            var idxops = entity.Select(o => new BulkIndexOperation<T>(o)).Cast<IBulkOperation>().ToList();
            bulkRequest.Operations = idxops;
            var response = ElasticClient.Bulk(bulkRequest);

            if (!response.IsValid)
                throw new ElasticsearchException("新增数据失败:" + response.OriginalException.Message);
        }

        /// <summary>
        ///     删除index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveIndex(string index)
        {
            if (!IndexExists(index)) return;
            var response = ElasticClient.DeleteIndex(index);

            if (!response.IsValid)
                throw new ElasticsearchException("删除index失败:" + response.OriginalException.Message);
        }

        /// <summary>
        ///     Alias 别名操作
        /// </summary>
        /// <param name="aliasRequest"></param>
        public IBulkAliasResponse Alias(IBulkAliasRequest aliasRequest)
        {
            var response = ElasticClient.Alias(aliasRequest);

            if (!response.IsValid)
                throw new ElasticsearchException("操作Alias失败:" +
                                    response.OriginalException.Message);
            return response;
        }

        /// <summary>
        ///     全文检索
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public ISearchResponse<T> SearchPage<T>
            (SearchRequest<T> searchRequest) where T : class
        {
            var response = ElasticClient
                .Search<T>(searchRequest);
            if (!response.IsValid)
                throw new ElasticsearchException("查询失败:" +
                                    response.OriginalException.Message);
            return response;
        }

        /// <summary>
        /// 查询指定数据
        /// </summary>
        /// <param name="request"></param>
        public T Get<T>(GetRequest request) where T : class
        {
            var response = ElasticClient
                .Get<T>(request);
            if (!response.IsValid)
                throw new ElasticsearchException("查询失败:" +
                                                 response.OriginalException.Message);
            return response.Source;
        }

        /// <summary>
        /// 删除指定数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        public IDeleteByQueryResponse DeleteByQuery<T>(DeleteByQueryRequest<T> deleteRequest) where T : class
        {
            var response = ElasticClient.DeleteByQuery(deleteRequest);
            if (!response.IsValid)
                throw new ElasticsearchException("删除失败:" +
                                                 response.OriginalException.Message);
            return response;
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public IUpdateResponse<T> Update<T>(IUpdateRequest<T, object> request) where T : class
        {
            var response = ElasticClient.Update(request);
            if (!response.IsValid)
                throw new ElasticsearchException("更新失败:" +
                                                 response.OriginalException.Message);
            return response;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public IUpdateResponse<T1> Update<T1, T2>(IUpdateRequest<T1, T2> request) where T1 : class where T2 : class
        {
            var response = ElasticClient.Update(request);
            if (!response.IsValid)
                throw new ElasticsearchException("更新失败:" +
                                                 response.OriginalException.Message);
            return response;
        }
    }
}