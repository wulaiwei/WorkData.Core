// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData
// 文件名：NullLoadType.cs
// 创建标识：吴来伟 2017-12-12 9:18
// 创建描述：
//
// 修改标识：吴来伟2017-12-12 9:19
// 修改描述：
//  ------------------------------------------------------------------------------

namespace WorkData.Extensions.Types
{
    public class NullLoadType
    {
        /// <summary>
        ///     Singleton instance.
        /// </summary>
        public static ILoadType Instance { get; } = new LoadType();
    }
}