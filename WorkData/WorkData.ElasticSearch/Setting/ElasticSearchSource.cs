// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.ElasticSearch
// 文件名：ElasticSearchSource.cs
// 创建标识：吴来伟 2018-04-26 14:41
// 创建描述：
//
// 修改标识：吴来伟2018-04-26 15:10
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Elasticsearch.Net;
using Nest;
using System;
using System.Linq;
using WorkData.Dependency;
using WorkData.ElasticSearch.Config;

#endregion

namespace WorkData.ElasticSearch.Setting
{
    /// <summary>
    /// ElasticSearchSource
    /// </summary>
    public class ElasticSearchSource
    {
        /// <summary>
        ///     ElasticSearchSourceConfig
        /// </summary>
        public static ElasticSearchSourceConfig ElasticSearchSourceConfig { get; } =
            IocManager.ServiceLocatorCurrent.GetInstance<ElasticSearchSourceConfig>();

        /// <summary>
        /// Node
        /// </summary>
        public static Uri[] Node => ElasticSearchSourceConfig.Uris.Select(x => new Uri(x)).ToArray();

        public static ConnectionSettings CreateInstance(string connectionString = null)
        {
            var connectionPool = new SniffingConnectionPool(Node);
            //设置连接
            return new ConnectionSettings(connectionPool)
                .DefaultIndex(ElasticSearchSourceConfig.DefaultIndex)
                .BasicAuthentication("cloud", "jwellcloud");
        }
    }
}