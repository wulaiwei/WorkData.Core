// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：ObejctExtensions.cs
// 创建标识：吴来伟 2017-12-21 15:58
// 创建描述：
//
// 修改标识：吴来伟2017-12-21 15:58
// 修改描述：
//  ------------------------------------------------------------------------------
namespace WorkData.Code.Extensions
{
    public static class ObejctExtensions
    {
        /// <summary>
        /// Used to simplify and beautify casting an object to a type.
        /// </summary>
        /// <typeparam name="T">Type to be casted</typeparam>
        /// <param name="obj">Object to cast</param>
        /// <returns>Casted object</returns>
        public static T As<T>(this object obj)
            where T : class
        {
            return obj as T;
        }
    }
}