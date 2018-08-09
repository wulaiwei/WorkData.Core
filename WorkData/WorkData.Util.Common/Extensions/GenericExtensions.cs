// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Util.Common
// 文件名：GenericExtensions.cs
// 创建标识：吴来伟 2018-05-31 15:43
// 创建描述：
//
// 修改标识：吴来伟2018-05-31 15:43
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Text;

namespace WorkData.Util.Common.Extensions
{
    /// <summary>
    ///   泛型扩展类
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        ///  泛型转换成Request Form Data
        /// </summary>
        /// <returns></returns>
        public static string GenericToFormData<T>(this T input) where T : class
        {
            var type = typeof(T);
            var properties = type.GetProperties();

            var returnSb = new StringBuilder();

            foreach (var property in properties)
            {
                if (property == null) continue;

                var o = property.GetValue(input, null);

                returnSb.Append($"&{property.Name}={o}");
            }

            var tempStr = returnSb.ToString();

            return tempStr.Length > 0 ? $"{tempStr.Substring(1)}" : string.Empty;
        }
    }
}