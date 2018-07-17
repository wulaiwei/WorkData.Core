// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Infrastructure
// 文件名：IDbContentProvider.cs
// 创建标识：吴来伟 2017-12-04 21:45
// 创建描述：
//
// 修改标识：吴来伟2017-12-04 21:45
// 修改描述：
//  ------------------------------------------------------------------------------
namespace WorkData.EntityFramework.Repositories
{
    /// <summary>
    /// IDbContextProvider
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    public interface IDbContextProvider<out TDbContext>
    {
        /// <summary>
        /// GetContent
        /// </summary>
        /// <returns></returns>
        TDbContext GetContent();

        /// <summary>
        /// GetContent
        /// </summary>
        /// <param name="conString"></param>
        /// <returns></returns>
        TDbContext GetContent(string conString);
    }
}