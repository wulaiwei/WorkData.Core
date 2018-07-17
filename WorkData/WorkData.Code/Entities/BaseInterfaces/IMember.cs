// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：IMember.cs
// 创建标识：吴来伟 2017-12-18 17:43
// 创建描述：
//
// 修改标识：吴来伟2017-12-18 17:43
// 修改描述：
//  ------------------------------------------------------------------------------
namespace WorkData.Code.Entities.BaseInterfaces
{
    /// <summary>
    /// 所属Member(支持Identity 认证)
    /// </summary>
    public interface IMember
    {
        string MemberUserId { get; set; }
    }
}