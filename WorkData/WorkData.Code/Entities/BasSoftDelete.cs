// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：BasSoftDelete.cs
// 创建标识：吴来伟 2017-12-19 11:24
// 创建描述：
//
// 修改标识：吴来伟2017-12-19 11:24
// 修改描述：
//  ------------------------------------------------------------------------------
namespace WorkData.Code.Entities
{
    /// <summary>
    /// 基础软删除
    /// </summary>
    public class BasSoftDelete : ISoftDelete
    {
        /// <summary>
        /// 是否删除
        /// </summary>
        public virtual bool IsDelete { get; set; }
    }
}