// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.EntityFramework
// 文件名：IRepositoryDbConntext.cs
// 创建标识：吴来伟 2018-02-12 10:21
// 创建描述：
//
// 修改标识：吴来伟2018-02-12 10:21
// 修改描述：
//  ------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace WorkData.EntityFramework.Repositories
{
    public interface IRepositoryDbConntext
    {
        DbContext GetDbContext();
    }
}