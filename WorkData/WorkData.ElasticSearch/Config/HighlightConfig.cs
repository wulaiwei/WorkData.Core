// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.ElasticSearch
// 文件名：HighlightConfig.cs
// 创建标识：吴来伟 2018-05-03 14:59
// 创建描述：
//
// 修改标识：吴来伟2018-05-03 14:59
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WorkData.ElasticSearch.Config
{
    public class HighlightConfig<T>
    {
        public string Tag { get; set; }

        public List<Expression<Func<T, object>>> HighlightConfigExpression { get; set; }
    }
}