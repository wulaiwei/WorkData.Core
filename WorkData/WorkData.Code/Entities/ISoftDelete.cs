// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：ISoftDelete.cs
// 创建标识：吴来伟 2017-12-18 17:55
// 创建描述：
//
// 修改标识：吴来伟2017-12-18 17:55
// 修改描述：
//  ------------------------------------------------------------------------------
namespace WorkData.Code.Entities
{
    /// <summary>
    /// ISoftDelete
    /// </summary>
    public interface ISoftDelete
    {
        bool IsDelete { get; set; }
    }
}