// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.ElasticSearch
// 文件名：NullElasticClient.cs
// 创建标识：吴来伟 2018-04-26 17:38
// 创建描述：
//
// 修改标识：吴来伟2018-04-26 17:39
// 修改描述：
//  ------------------------------------------------------------------------------

using WorkData.ElasticSearch.Setting;
using Nest;

namespace WorkData.ElasticSearch.Impl
{
    public class NullElasticClient
    {
        /// <summary>
        ///     Singleton instance.
        /// </summary>
        public static ElasticClient Instance { get; } =
            new ElasticClient(ElasticSearchSource.CreateInstance());
    }
}