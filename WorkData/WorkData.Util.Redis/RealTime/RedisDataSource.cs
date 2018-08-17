// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Util.Redis
// 文件名：RedisDataSource.cs
// 创建标识：吴来伟 2018-03-21 14:22
// 创建描述：
//
// 修改标识：吴来伟2018-03-21 14:24
// 修改描述：
//  ------------------------------------------------------------------------------

using StackExchange.Redis;
using WorkData.Dependency;

namespace WorkData.Util.Redis.RealTime
{
    public class RedisDataSource
    {
        /// <summary>
        /// WorkDataRedisConfig
        /// </summary>
        public static WorkDataRedisConfig WorkDataRedisConfig { get; }
            = IocManager.Instance.Resolve<WorkDataRedisConfig>();

        private static ConnectionMultiplexer _instance;
        private static readonly object Locker = new object();

        /// <summary>
        /// 单例模式获取redis连接实例
        /// </summary>
        public static ConnectionMultiplexer Instance
        {
            get
            {
                lock (Locker)
                {
                    if (_instance != null) return _instance;
                    var config = WorkDataRedisConfig.InitConfigurationOptions();
                    _instance = ConnectionMultiplexer.Connect(config);
                }
                return _instance;
            }
        }
    }
}