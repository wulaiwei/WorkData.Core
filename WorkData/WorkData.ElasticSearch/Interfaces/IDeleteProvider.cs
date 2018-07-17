// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.ElasticSearch
// 文件名：IDeleteProvider.cs
// 创建标识：吴来伟 2018-05-03 16:15
// 创建描述：
//  
// 修改标识：吴来伟2018-05-03 16:15
// 修改描述：
//  ------------------------------------------------------------------------------

using Nest;

namespace WorkData.ElasticSearch.Interfaces
{
    public interface IDeleteProvider
    {
        IDeleteByQueryResponse DeleteByQuery<T>(DeleteByQueryRequest<T> deleteRequest) where T : class;
    }
}