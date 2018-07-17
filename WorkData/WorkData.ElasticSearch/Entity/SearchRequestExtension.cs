// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.ElasticSearch
// 文件名：SearchRequestExtension.cs
// 创建标识：吴来伟 2018-07-17 13:30
// 创建描述：
//  
// 修改标识：吴来伟2018-07-17 13:33
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Collections.Generic;
using System.Linq;
using Nest;
using WorkData.ElasticSearch.Config;
using WorkData.Util.Common.Helpers;

#endregion

namespace WorkData.ElasticSearch.Entity
{
    /// <summary>
    ///     Nest查询扩展方法
    /// </summary>
    public static class SearchRequestExtension
    {
        /// <summary>
        ///     初始化query
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <param name="predicate"></param>
        public static ISearchRequest InitQueryContainer(this ISearchRequest searchRequest, IPredicate predicate)
        {
            if (predicate != null)
            {
                searchRequest.Query = predicate.GetQuery(searchRequest.Query);
            }
            return searchRequest;
        }

        /// <summary>
        ///     初始化sort
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <param name="sorts"></param>
        public static ISearchRequest InitSort(this ISearchRequest searchRequest, List<ISort> sorts)
        {
            if (sorts != null)
            {
                searchRequest.Sort = sorts;
            }
            return searchRequest;
        }

        /// <summary>
        ///     初始化高亮配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="searchRequest"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static ISearchRequest InitHighlight<T>(this ISearchRequest searchRequest, HighlightConfig<T> config)
        {
            if (config == null)
                return searchRequest;
            var dic = new Dictionary<Field, IHighlightField>();

            foreach (var expression in config.HighlightConfigExpression)
            {
                var propertySearchName = (PropertySearchNameAttribute)
                    LoadAttributeHelper.LoadAttributeByType<T, PropertySearchNameAttribute>(expression);

                dic.Add(propertySearchName.Name, new HighlightField());
            }
            searchRequest.Highlight = new Highlight
            {
                PreTags = new[] {$"<{config.Tag}>"},
                PostTags = new[] {$"</{config.Tag}>"},
                Encoder = HighlighterEncoder.Html,
                Fields = dic
            };
            return searchRequest;
        }

        /// <summary>
        ///     初始化 GroupBy
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <param name="terms"></param>
        /// <returns></returns>
        public static ISearchRequest InitGroupBy(this ISearchRequest searchRequest, List<IFieldTerms> terms)
        {
            if (!terms.Any())
                return searchRequest;
            var container = terms.ToDictionary<IFieldTerms, string, IAggregationContainer>
            (term => term.SearchKey, term => new AggregationContainer
            {
                Terms = new TermsAggregation("states")
                {
                    Field = term.PropertyName,
                    Size = term.Size
                }
            });

            searchRequest.Aggregations = new AggregationDictionary(container);
            return searchRequest;
        }
    }
}