using WorkData.ElasticSearch.Entity;
using WorkData.Util.Common.Extensions;

namespace WorkDataEs.WorkDataElasticSearchs.Contents.Dto
{
    public class BrandResponse : BaseAggResponse<string>
    {
        /// <summary>
        /// 品牌首字母
        /// </summary>
        public string BrandFirstLetters => Key.SplitString('&');

        /// <summary>
        /// 品牌
        /// </summary>
        public string Brand => Key.SplitString('&', true);
    }
}