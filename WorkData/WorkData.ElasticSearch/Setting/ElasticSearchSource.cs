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

using WorkData.ElasticSearch.Config;
using Nest;
using System;
using WorkData.Dependency;

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
            IocManager.Instance.Resolve<ElasticSearchSourceConfig>();

        /// <summary>
        /// Node
        /// </summary>
        public static Uri Node => new Uri(ElasticSearchSourceConfig.Uri);

        public static ConnectionSettings CreateInstance(string connectionString = null)
        {
            //设置连接
           return new ConnectionSettings(Node)
                .DefaultIndex(ElasticSearchSourceConfig.DefaultIndex)
                .BasicAuthentication("cloud", "jwellcloud");
        }
    }
}