// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：Cloud.Util.Elasticsearch
// 文件名：ElasticsearchPage.cs
// 创建标识：吴来伟 2018-01-10 15:02
// 创建描述：
//
// 修改标识：吴来伟2018-01-10 15:07
// 修改描述：
//  ------------------------------------------------------------------------------

using Nest;
using WorkData.Util.Common.Pages;

namespace WorkData.ElasticSearch.Entity
{
    /// <summary>
    ///     ElasticsearchPage
    /// </summary>
    public class ElasticsearchPage<T> : PageEntity
    {
        public string Index { get; set; }

        public ElasticsearchPage(string index)
        {
            Index = index;
        }

        /// <summary>
        /// InitSearchRequest
        /// </summary>
        /// <returns></returns>
        public SearchRequest<T> InitSearchRequest()
        {
            return new SearchRequest<T>(Index)
            {
                From = (PageIndex - 1) * PageSize,
                Size = PageSize
            };
        }
    }
}