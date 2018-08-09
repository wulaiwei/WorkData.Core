// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.ElasticSearch
// 文件名：HighlightFieldExtension.cs
// 创建标识：吴来伟 2018-05-03 15:36
// 创建描述：
//
// 修改标识：吴来伟2018-05-03 15:36
// 修改描述：
//  ------------------------------------------------------------------------------

using Nest;
using System.Linq;

namespace WorkData.ElasticSearch.Entity
{
    public static class HighlightFieldExtension
    {
        public static object Highlight(this HighlightFieldDictionary highlightFieldDictionary, object data, string key)
        {
            var result = highlightFieldDictionary == null ? data : highlightFieldDictionary.Keys.Contains(key) ?
                string.Join("", highlightFieldDictionary[key].Highlights) : data;
            return result;
        }
    }
}