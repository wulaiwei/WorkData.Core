// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Util.Redis
// 文件名：NullRedisManager.cs
// 创建标识：吴来伟 2018-03-21 14:22
// 创建描述：
//
// 修改标识：吴来伟2018-03-21 14:24
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using WorkData.Dependency;
using WorkData.Util.Redis.Impl;

#endregion

namespace WorkData.Util.Redis
{
    /// <summary>
    ///     NullRedisManager
    /// </summary>
    public class NullRedisManager
    {
        /// <summary>
        ///     Singleton InstanceManager.
        /// </summary>
        public static BaseRedisServiceManager InstanceManager { get; } =
            IocManager.Instance.Resolve<BaseRedisServiceManager>();
    }
}