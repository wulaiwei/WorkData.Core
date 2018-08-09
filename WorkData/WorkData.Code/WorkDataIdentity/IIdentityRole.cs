// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：IIdentityRole.cs
// 创建标识：吴来伟 2018-05-28 17:24
// 创建描述：
//
// 修改标识：吴来伟2018-05-30 11:16
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;

#endregion

namespace WorkData.Code.WorkDataIdentity
{
    /// <summary>
    ///     IIdentityRole
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IIdentityRole<TPrimaryKey> where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        //
        //     Gets or sets the primary key for this role.
        TPrimaryKey Id { get; set; }

        //
        //     Gets or sets the name for this role.
        string RoleName { get; set; }
    }
}