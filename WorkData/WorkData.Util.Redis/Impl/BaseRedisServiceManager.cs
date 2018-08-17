// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Util.Redis
// 文件名：BaseRedisServiceManager.cs
// 创建标识：吴来伟 2018-05-07 18:38
// 创建描述：
//
// 修改标识：吴来伟2018-07-11 10:00
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using WorkData.Util.Redis.Interface;

#endregion

namespace WorkData.Util.Redis.Impl
{
    /// <summary>
    ///     BaseRedisService
    /// </summary>
    public class BaseRedisServiceManager
    {
        #region IOC

        private readonly IRedisService _redisService;

        public BaseRedisServiceManager(IRedisService redisService)
        {
            _redisService = redisService;
        }

        #endregion

        /// <summary>
        ///     key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            return _redisService.Get(key);
        }

        /// <summary>
        ///     Get
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TEntity Get<TEntity>(string key)
        {
            return _redisService.Get<TEntity>(key);
        }

        /// <summary>
        ///     Add
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool Add(string key, string value)
        {
            return _redisService.Add(key, value);
        }

        /// <summary>
        ///     过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime"></param>
        /// <returns></returns>
        public bool Add(string key, string value, TimeSpan expireTime)
        {
            return _redisService.Add(key, value, expireTime);
        }

        /// <summary>
        ///     删除键值
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            _redisService.Remove(key);
        }
    }
}