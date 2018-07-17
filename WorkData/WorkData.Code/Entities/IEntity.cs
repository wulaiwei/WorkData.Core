// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Infrastructure
// 文件名：IEntity.cs
// 创建标识：吴来伟 2017-12-04 17:40
// 创建描述：
//
// 修改标识：吴来伟2017-12-04 17:40
// 修改描述：
//  ------------------------------------------------------------------------------
namespace WorkData.Code.Entities
{
    /// <summary>
    /// IEntity
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}