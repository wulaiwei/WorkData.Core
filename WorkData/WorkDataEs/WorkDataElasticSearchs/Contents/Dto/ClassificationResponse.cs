using WorkData.ElasticSearch.Entity;
using WorkData.Util.Common.Extensions;

namespace WorkDataEs.WorkDataElasticSearchs.Contents.Dto
{
    public class ClassificationResponse : BaseAggResponse<string>
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string ClassificationName => Key.SplitString('&', true);

        /// <summary>
        /// 分类代码
        /// </summary>
        public string ClassificationCode => Key.SplitString('&');

        /// <summary>
        /// 分类ID
        /// </summary>
        public string ClassificationId => ClassificationCode.SplitString(',');
    }
}