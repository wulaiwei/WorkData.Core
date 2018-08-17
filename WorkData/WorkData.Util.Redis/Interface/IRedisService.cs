// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Util.Redis
// 文件名：IRedisService.cs
// 创建标识：吴来伟 2018-03-21 14:22
// 创建描述：
//
// 修改标识：吴来伟2018-03-21 14:24
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;

#endregion

namespace WorkData.Util.Redis.Interface
{
    /// <summary>
    ///     IRedisService
    /// </summary>
    public interface IRedisService
    {
        /// <summary>
        ///     key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string Get(string key);

        /// <summary>
        ///     获取
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        TEntity Get<TEntity>(string key);

        /// <summary>
        ///     Add
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        bool Add(string key, string value);

        /// <summary>
        ///     Add
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime"></param>
        bool Add(string key, string value, TimeSpan expireTime);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);
    }
}