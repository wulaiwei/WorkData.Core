// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData
// 文件名：NullTypeFinder.cs
// 创建标识：吴来伟 2018-07-26 10:04
// 创建描述：
//  
// 修改标识：吴来伟2018-07-26 10:05
// 修改描述：
//  ------------------------------------------------------------------------------

namespace WorkData.Extensions.TypeFinders
{
    public class NullTypeFinder
    {
        /// <summary>
        ///     Singleton instance.
        /// </summary>
        public static ITypeFinder Instance { get; } = new WebAppTypeFinder();
    }
}