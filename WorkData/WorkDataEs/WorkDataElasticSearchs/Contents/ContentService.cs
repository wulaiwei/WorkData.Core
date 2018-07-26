#region

using Nest;
using System.Collections.Generic;
using System.Linq;
using WorkData.ElasticSearch;
using WorkData.ElasticSearch.Entity;
using WorkData.ElasticSearch.Interfaces;
using WorkData.Util.Common.Extensions;
using WorkData.Util.Common.Helpers;
using WorkDataEs.WorkDataElasticSearchs.Contents.Dto;

#endregion

namespace WorkDataEs.WorkDataElasticSearchs.Contents
{
    public class ContentService : IContentService
    {
        private readonly IIndexProvider _indexProvider;
        private readonly ISearchProvider _searchProvider;
        private readonly IDeleteProvider _deleteProvider;
        private readonly IUpdateProvider _updateProvider;

        public ContentService(
            IIndexProvider indexProvider, ISearchProvider searchProvider,
            IDeleteProvider deleteProvider, IUpdateProvider updateProvider)
        {
            _indexProvider = indexProvider;
            _searchProvider = searchProvider;
            _deleteProvider = deleteProvider;
            _updateProvider = updateProvider;
        }

        /// <summary>
        ///     批量新增
        /// </summary>
        /// <param name="content"></param>
        /// <param name="index"></param>
        public void BlukIndex(List<Content> content, string index)
        {
            _indexProvider.BulkIndex(content, index);
        }

        /// <summary>
        ///     Search
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="requestContentDto"></param>
        public ContentResponse Search(int pageIndex, int pageSize, RequestContentDto requestContentDto)
        {
            var elasticsearchPage = new ElasticsearchPage<Content>("content_test")
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            #region terms 分组

            var terms = new List<IFieldTerms>();
            var classificationGroupBy = "searchKey_classification";
            var brandGroupBy = "searchKey_brand";

            #endregion

            var searchRequest = elasticsearchPage.InitSearchRequest();
            var predicateList = new List<IPredicate>();
            //分类ID
            if (requestContentDto.CategoryId != null)
                predicateList.Add(Predicates.Field<Content>(x => x.ClassificationCode, ExpressOperator.Like,
                    requestContentDto.CategoryId));
            else
                terms.Add(Predicates.FieldTerms<Content>(x => x.ClassificationGroupBy, classificationGroupBy, 200));

            //品牌
            if (string.IsNullOrWhiteSpace(requestContentDto.Brand))
                terms.Add(Predicates.FieldTerms<Content>(x => x.BrandGroupBy, brandGroupBy, 200));
            //供应商名称
            if (!string.IsNullOrWhiteSpace(requestContentDto.BaseType))
                predicateList.Add(Predicates.Field<Content>(x => x.BaseType, ExpressOperator.Like,
                    requestContentDto.BaseType));
            //是否自营
            if (requestContentDto.IsSelfSupport == 1)
                predicateList.Add(Predicates.Field<Content>(x => x.IsSelfSupport, ExpressOperator.Eq,
                    requestContentDto.IsSelfSupport));
            //最大价格
            if (requestContentDto.MaxPrice != null)
                predicateList.Add(Predicates.Field<Content>(x => x.UnitPrice, ExpressOperator.Le,
                    requestContentDto.MaxPrice));
            //最小价格
            if (requestContentDto.MinPrice != null)
                predicateList.Add(Predicates.Field<Content>(x => x.UnitPrice, ExpressOperator.Ge,
                    requestContentDto.MinPrice));
            //关键词
            if (!string.IsNullOrWhiteSpace(requestContentDto.SearchKey))
                predicateList.Add(Predicates.Field<Content>(x => x.Title, ExpressOperator.Like,
                    requestContentDto.SearchKey));

            //规整排序
            var sortConfig = SortOrderRule(requestContentDto.SortKey);
            var sorts = new List<ISort>
            {
                Predicates.Sort<Content>(sortConfig.Key, sortConfig.SortOrder)
            };

            var predicate = Predicates.Group(GroupOperator.And, predicateList.ToArray());
            //构建或查询
            var predicateListOr = new List<IPredicate>();
            if (!string.IsNullOrWhiteSpace(requestContentDto.Brand))
            {
                var array = requestContentDto.Brand.Split(',').ToList();
                predicateListOr
                    .AddRange(array.Select
                        (item => Predicates.Field<Content>(x => x.Brand, ExpressOperator.Like, item)));
            }

            var predicateOr = Predicates.Group(GroupOperator.Or, predicateListOr.ToArray());

            var predicatecCombination = new List<IPredicate> { predicate, predicateOr };
            var pgCombination = Predicates.Group(GroupOperator.And, predicatecCombination.ToArray());

            searchRequest.InitQueryContainer(pgCombination)
                .InitSort(sorts)
                .InitHighlight(requestContentDto.HighlightConfigEntity)
                .InitGroupBy(terms);

            var data = _searchProvider.SearchPage(searchRequest);

            #region terms 分组赋值

            var classificationResponses = requestContentDto.CategoryId != null
                ? null
                : data.Aggregations.Terms(classificationGroupBy).Buckets
                    .Select(x => new ClassificationResponse
                    {
                        Key = x.Key.ToString(),
                        DocCount = x.DocCount
                    }).ToList();

            var brandResponses = !string.IsNullOrWhiteSpace(requestContentDto.Brand)
                ? null
                : data.Aggregations.Terms(brandGroupBy).Buckets
                    .Select(x => new BrandResponse
                    {
                        Key = x.Key.ToString(),
                        DocCount = x.DocCount
                    }).ToList();

            #endregion

            //初始化

            #region 高亮

            var titlePropertySearchName = (PropertySearchNameAttribute)
                LoadAttributeHelper.LoadAttributeByType<Content, PropertySearchNameAttribute>(x => x.Title);

            var list = data.Hits.Select(c => new Content
            {
                Key = c.Source.Key,
                Title = (string)c.Highlights.Highlight(c.Source.Title, titlePropertySearchName.Name),
                ImgUrl = c.Source.ImgUrl,
                BaseType = c.Source.BaseType,
                BelongMemberName = c.Source.BelongMemberName,
                Brand = c.Source.Brand,
                Code = c.Source.Code,
                BrandFirstLetters = c.Source.BrandFirstLetters,
                ClassificationName = c.Source.ClassificationName,
                ResourceStatus = c.Source.ResourceStatus,
                BrandGroupBy = c.Source.BrandGroupBy,
                ClassificationGroupBy = c.Source.ClassificationGroupBy,
                ClassificationCode = c.Source.ClassificationCode,
                IsSelfSupport = c.Source.IsSelfSupport,
                UnitPrice = c.Source.UnitPrice
            }).ToList();

            #endregion

            var contentResponse = new ContentResponse
            {
                Records = (int)data.Total,
                PageIndex = elasticsearchPage.PageIndex,
                PageSize = elasticsearchPage.PageSize,
                Contents = list,
                BrandResponses = brandResponses,
                ClassificationResponses = classificationResponses
            };
            return contentResponse;
        }

        /// <summary>
        ///     删除指定数据
        /// </summary>
        public void DeleteByQuery(string key)
        {
            var request = new DeleteByQueryRequest<Content>("content_test");
            var predicateList = new List<IPredicate>
            {
                Predicates.Field<Content>(x => x.Key, ExpressOperator.Eq, key)
            };
            var predicate = Predicates.Group(GroupOperator.And, predicateList.ToArray());
            request.InitDelteQueryContainer(predicate);

            _deleteProvider.DeleteByQuery(request);
        }

        /// <summary>
        ///     更新数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public void UpdateByKey(string key, object data)
        {
            var request = new UpdateRequest<Content, object>("content_test", "content_test", key)
            {
                Doc = data
            };
            _updateProvider.Update(request);
        }

        /// <summary>
        ///     新增
        /// </summary>
        /// <param name="content"></param>
        /// <param name="index"></param>
        public void Index(Content content, string index)
        {
            _indexProvider.Index(content, index);
        }

        /// <summary>
        ///     排序规则验证
        /// </summary>
        /// <param name="sortKey"></param>
        private SortKeyConfig SortOrderRule(string sortKey)
        {
            //初始化对象
            var sortKeyConfig = new SortKeyConfig { Key = "_score", SortOrder = SortOrder.Descending };
            //设置默认值
            if (string.IsNullOrWhiteSpace(sortKey) || !sortKeyConfig.SortKeyConfigs.Contains(sortKey))
                return sortKeyConfig;

            //转换为小写
            sortKey = sortKey.ToLower();

            var orderArray = sortKey.BreakUpOptions('-');
            if (orderArray == null || orderArray.Length != 2)
                return sortKeyConfig;

            var key = orderArray.FirstOrDefault();
            var sortOrder = orderArray.LastOrDefault();

            //赋值
            sortKeyConfig.Key = key;
            sortKeyConfig.SortOrder = sortOrder == "desc" ? SortOrder.Descending : SortOrder.Ascending;
            return sortKeyConfig;
        }
    }
}