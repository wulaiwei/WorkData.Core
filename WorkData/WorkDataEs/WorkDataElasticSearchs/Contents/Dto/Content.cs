using Nest;
using WorkData.ElasticSearch.Entity;

namespace WorkDataEs.WorkDataElasticSearchs.Contents.Dto
{
    [ElasticsearchType(IdProperty = "key", Name = "content_Test")]
    public class Content
    {
        /// <summary>
        /// 键值
        /// </summary>
        /// Text 代表字符串类型  Name 为名称   Analyzer 分词方式（ik_max_word采用Ik）
        /// Norms 无需筛选字段配置为不参与评分 Similarity 相似性算法 （eg:LMDirichlet）
        /// DocValues 设置是否对字段进行排序或聚合  ignore_malformed 忽略格式异常 Coerce 强制格式化
        /// 更多参考连接 https://www.elastic.co/guide/en/elasticsearch/reference/current/mapping-params.html
        [Text(Name = "key", Fielddata = true)]
        [PropertySearchName("key")]
        public string Key { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        /// , Analyzer = "ik_max_word"
        [Text(Name = "title", Analyzer = "ik_max_word")]
        [PropertySearchName("title")]
        public string Title { get; set; }

        /// <summary>
        /// 图片连接
        /// </summary>
        [Text(Name = "img_url", Norms = false)]
        [PropertySearchName("img_url")]
        public string ImgUrl { get; set; }

        /// <summary>
        /// 资源代码
        /// </summary>
        [Text(Name = "code", Analyzer = "ik_max_word")]
        [PropertySearchName("code")]
        public string Code { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [Number(Name = "unit_price", DocValues = true, IgnoreMalformed = true, Coerce = true)]
        [PropertySearchName("unit_price")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 基础类型
        /// </summary>
        [Text(Name = "base_type", Analyzer = "ik_max_word")]
        [PropertySearchName("base_type")]
        public string BaseType { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        [Text(Name = "classification_name", Analyzer = "ik_max_word")]
        [PropertySearchName("classification_name")]
        public string ClassificationName { get; set; }

        /// <summary>
        /// 分类代码
        /// </summary>
        [Text(Name = "classification_code", Analyzer = "ik_max_word")]
        [PropertySearchName("classification_code")]
        public string ClassificationCode { get; set; }

        /// <summary>
        /// 品牌首字母
        /// </summary>
        [Text(Name = "brand_first_letters")]
        [PropertySearchName("brand_first_letters")]
        public string BrandFirstLetters { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        [Text(Name = "brand", Analyzer = "ik_max_word")]
        [PropertySearchName("brand")]
        public string Brand { get; set; }

        /// <summary>
        /// 属于用户
        /// </summary>
        [Text(Name = "belong_member_name", Analyzer = "ik_max_word")]
        [PropertySearchName("belong_member_name")]
        public string BelongMemberName { get; set; }

        /// <summary>
        /// 是否自营
        /// </summary>
        [Text(Name = "is_self_support")]
        [PropertySearchName("is_self_support")]
        public int IsSelfSupport { get; set; }

        /// <summary>
        /// 资源状态
        /// </summary>
        [Text(Name = "resource_status")]
        [PropertySearchName("resource_status")]
        public int ResourceStatus { get; set; }

        /// <summary>
        /// brand_group_by
        /// </summary>
        [Keyword(Name = "brand_group_by")]
        [PropertySearchName("brand_group_by")]
        public string BrandGroupBy { get; set; }

        /// <summary>
        /// ClassificationGroupBy
        /// </summary>
        [Keyword(Name = "classification_group_by")]
        [PropertySearchName("classification_group_by")]
        public string ClassificationGroupBy { get; set; }
    }
}