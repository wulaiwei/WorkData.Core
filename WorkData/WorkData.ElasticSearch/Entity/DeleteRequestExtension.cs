// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.ElasticSearch
// 文件名：DeleteRequestExtension.cs
// 创建标识：吴来伟 2018-05-03 16:32
// 创建描述：
//  
// 修改标识：吴来伟2018-05-03 16:32
// 修改描述：
//  ------------------------------------------------------------------------------

using Nest;

namespace WorkData.ElasticSearch.Entity
{
    public static class DeleteRequestExtension
    {
        /// <summary>
        /// 初始化query
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <param name="predicate"></param>
        public static IDeleteByQueryRequest InitDelteQueryContainer(this IDeleteByQueryRequest searchRequest, IPredicate predicate)
        {
            if (predicate != null)
            {
                searchRequest.Query = predicate.GetQuery(searchRequest.Query);
            }
            return searchRequest;

        }
    }
}