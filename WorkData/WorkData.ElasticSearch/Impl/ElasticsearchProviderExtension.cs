// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：Cloud.Util.Elasticsearch
// 文件名：ElasticsearchProviderExtension.cs
// 创建标识：吴来伟 2018-01-10 15:02
// 创建描述：
//
// 修改标识：吴来伟2018-01-10 15:05
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Nest;
using System;

#endregion

namespace WorkData.ElasticSearch.Impl
{
    /// <summary>
    ///     ElasticsearchProviderExtension
    /// </summary>
    public static class ElasticsearchProviderExtension
    {
        /// <summary>
        ///     InitializeIndexMap
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="index"></param>
        public static void InitializeIndexMap<T>(this IElasticClient client, string index) where T : class
        {
            var descriptor = new CreateIndexDescriptor(index)
                .Mappings(ms => ms
                    .Map<T>(m => m.AutoMap())
                )
                .Settings(s => s.NumberOfShards(1)
                .NumberOfReplicas(0));
            var response = client.CreateIndex(descriptor);

            if (!response.IsValid)
                throw new Exception("新增Index:" + response.OriginalException.Message);
        }

        /// <summary>
        ///     InitializeIndexMap
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="index"></param>
        /// <param name="numberOfShards"></param>
        /// <param name="numberOfReplicas"></param>
        public static void InitializeIndexMap<T>(this IElasticClient client, string index,int numberOfShards,int numberOfReplicas) where T : class
        {
            var descriptor = new CreateIndexDescriptor(index)
                .Mappings(ms => ms
                    .Map<T>(m => m.AutoMap())
                )
                .Settings(s => s.NumberOfShards(1)
                    .NumberOfReplicas(0));
            var response = client.CreateIndex(descriptor);

            if (!response.IsValid)
                throw new Exception("新增Index:" + response.OriginalException.Message);
        }

        /// <summary>
        ///     InitializeIndexMap
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="client"></param>
        /// <param name="index"></param>
        public static void InitializeIndexMap<T1, T2>(this IElasticClient client, string index)
            where T1 : class where T2 : class
        {
            var descriptor = new CreateIndexDescriptor(index)
                .Mappings(ms => ms
                    .Map<T1>(m => m.AutoMap())
                    .Map<T2>(m => m.AutoMap())
                );
            client.CreateIndex(descriptor);
        }
    }
}