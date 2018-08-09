// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.ElasticSearch
// 文件名：PropertySearchNameAttribute.cs
// 创建标识：吴来伟 2018-05-03 10:46
// 创建描述：
//
// 修改标识：吴来伟2018-05-03 10:46
// 修改描述：
//  ------------------------------------------------------------------------------

using System;

namespace WorkData.ElasticSearch.Entity
{
    public class PropertySearchNameAttribute : Attribute
    {
        public PropertySearchNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}