// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.ElasticSearch
// 文件名：BaseAggResponse.cs
// 创建标识：吴来伟 2018-05-16 17:13
// 创建描述：
//  
// 修改标识：吴来伟2018-05-16 17:13
// 修改描述：
//  ------------------------------------------------------------------------------
namespace WorkData.ElasticSearch.Entity
{
    public class BaseAggResponse<T>
    {
        public T Key { get; set; }

        public long? DocCount { get; set; }
    }
}