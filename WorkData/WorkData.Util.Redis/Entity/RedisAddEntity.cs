// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Util.Redis
// 文件名：RedisAddEntity.cs
// 创建标识：吴来伟 2018-05-15 10:32
// 创建描述：
//
// 修改标识：吴来伟2018-05-15 10:32
// 修改描述：
//  ------------------------------------------------------------------------------

namespace WorkData.Util.Redis.Entity
{
    public class RedisAddEntity
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public long ExpireTime { get; set; }
    }
}