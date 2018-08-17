// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Util.Redis
// 文件名：RedisService.cs
// 创建标识：吴来伟 2018-03-21 14:22
// 创建描述：
//
// 修改标识：吴来伟2018-03-21 14:23
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Autofac.Extras.DynamicProxy;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using WorkData.Util.Redis.Interface;
using WorkData.Util.Redis.RealTime;

#endregion

namespace WorkData.Util.Redis.Impl
{
    /// <summary>
    ///     Redis服务
    /// </summary>
    [Intercept("WorkDataRedisInterceptor")]
    public class RedisService : IRedisService
    {
        /// <summary>
        /// ConnectionMultiplexer
        /// </summary>
        public ConnectionMultiplexer ConnectionMultiplexer { get; set; }

        /// <summary>
        ///     RedisService
        /// </summary>
        public RedisService()
        {
            ConnectionMultiplexer = RedisDataSource.Instance;
        }

        /// <summary>
        ///     Get
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            var result = ConnectionMultiplexer.GetDatabase().StringGet(key);

            return result.ToString();
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TEntity Get<TEntity>(string key)
        {
            var data = ConnectionMultiplexer.GetDatabase().StringGet(key);
            return data.HasValue ?
                default(TEntity) :
                JsonConvert.DeserializeObject<TEntity>(data.ToString());
        }

        /// <summary>
        ///     Add
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Add(string key, string value)
        {
            try
            {
                ConnectionMultiplexer.GetDatabase().StringSet(key, value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     Add
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime"></param>
        /// <returns></returns>
        public bool Add(string key, string value, TimeSpan expireTime)
        {
            try
            {
                ConnectionMultiplexer.GetDatabase().StringSet(key, value, expireTime);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 删除键值
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            ConnectionMultiplexer.GetDatabase().KeyDelete(key);
        }
    }
}