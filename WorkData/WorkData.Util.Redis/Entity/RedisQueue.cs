// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Util.Redis
// 文件名：RedisQueue.cs
// 创建标识：吴来伟 2018-03-21 14:22
// 创建描述：
//
// 修改标识：吴来伟2018-03-21 14:23
// 修改描述：
//  ------------------------------------------------------------------------------

#region

#endregion

using Newtonsoft.Json;

namespace WorkData.Util.Redis.Entity
{
    /// <summary>
    ///     Redis队列对象
    /// </summary>
    public class RedisQueue<T> where T : class
    {
        /// <summary>
        ///     Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     EntityData
        /// </summary>
        public T Entity { get; set; }

        /// <summary>
        ///     EntityData
        /// </summary>
        public string EntityData => JsonConvert.SerializeObject(Entity);
    }
}