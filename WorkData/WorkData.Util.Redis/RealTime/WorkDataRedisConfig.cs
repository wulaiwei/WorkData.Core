// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Util.Redis
// 文件名：WorkDataRedisConfig.cs
// 创建标识：吴来伟 2018-05-07 14:28
// 创建描述：
//
// 修改标识：吴来伟2018-05-07 14:28
// 修改描述：
//  ------------------------------------------------------------------------------

using StackExchange.Redis;

namespace WorkData.Util.Redis.RealTime
{
    public class WorkDataRedisConfig
    {
        public string Ip { get; set; }

        public int Port { get; set; }

        public string Auth { get; set; }

        public int Db { get; set; }

        /// <summary>
        /// InitConfigurationOptions
        /// </summary>
        /// <returns></returns>
        public ConfigurationOptions InitConfigurationOptions()
        {
            var config = new ConfigurationOptions
            {
                AllowAdmin = string.IsNullOrWhiteSpace(Auth),
                AbortOnConnectFail = false,
                EndPoints =
                {
                    { Ip, Port }
                },
                DefaultDatabase = Db
            };

            if (!string.IsNullOrWhiteSpace(Auth))
            {
                config.Password = Auth;
            }
            return config;
        }
    }
}