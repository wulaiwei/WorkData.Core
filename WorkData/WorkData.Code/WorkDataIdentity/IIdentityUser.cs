// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：IIdentityUser.cs
// 创建标识：吴来伟 2018-05-28 17:24
// 创建描述：
//
// 修改标识：吴来伟2018-05-30 11:21
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;

#endregion

namespace WorkData.Code.WorkDataIdentity
{
    /// <summary>
    ///     IdentityUser
    /// </summary>
    public interface IIdentityUser<TPrimaryKey> where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        //
        //     Gets or sets the primary key for this user.
        TPrimaryKey Id { get; set; }
    }
}