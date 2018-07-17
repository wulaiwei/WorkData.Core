// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Util.Common
// 文件名：LoadAttributeHelper.cs
// 创建标识：吴来伟 2018-05-03 15:20
// 创建描述：
//  
// 修改标识：吴来伟2018-05-03 15:20
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using WorkData.Util.Common.Reflections;

namespace WorkData.Util.Common.Helpers
{
    /// <summary>
    /// LoadAttributeHelper
    /// </summary>
    public class LoadAttributeHelper
    {
        public static object LoadAttributeByType<T,TS>(Expression<Func<T, object>> expression)
        {
            var propertyInfo = ReflectionExtensionHelper.GetProperty(expression) as PropertyInfo;
            if (propertyInfo == null)
                throw new ArgumentNullException(typeof(T).Name);

            var attribute = propertyInfo.GetCustomAttributes(typeof(TS), false)
                .FirstOrDefault();
            if (attribute == null)
                throw new ArgumentNullException(typeof(TS).Name);
            return attribute;
        }
    }
}