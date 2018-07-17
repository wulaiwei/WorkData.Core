// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.EntityFramework
// 文件名：IEfContextFactory.cs
// 创建标识：吴来伟 2017-12-05 9:07
// 创建描述：
//
// 修改标识：吴来伟2017-12-05 9:07
// 修改描述：
//  ------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;

namespace WorkData.EntityFramework.UnitOfWorks
{
    /// <summary>
    /// IEfContextFactory
    /// </summary>
    public interface IEfContextFactory
    {
        TDbContext GetCurrentDbContext<TDbContext>(
            Dictionary<string, DbContext> dic,
            Dictionary<DbContext, IDbContextTransaction> tranDic)
            where TDbContext : DbContext;

        TDbContext GetCurrentDbContext<TDbContext>(
            Dictionary<string, DbContext> dic,
            Dictionary<DbContext, IDbContextTransaction> tranDic,
            string conString)
            where TDbContext : DbContext;
    }
}