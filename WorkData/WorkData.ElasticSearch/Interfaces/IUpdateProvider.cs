// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.ElasticSearch
// 文件名：IUpdateProvider.cs
// 创建标识：吴来伟 2018-05-03 16:51
// 创建描述：
//  
// 修改标识：吴来伟2018-05-03 16:51
// 修改描述：
//  ------------------------------------------------------------------------------

using Nest;

namespace WorkData.ElasticSearch.Interfaces
{
    public interface IUpdateProvider
    {
        IUpdateResponse<T> Update<T>(IUpdateRequest<T, object> request) where T : class;

        IUpdateResponse<T1> Update<T1, T2>(IUpdateRequest<T1, T2> request) where T1 : class where T2 : class;
    }
}