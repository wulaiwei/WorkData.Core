// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData
// 文件名：AsyncHelper.cs
// 创建标识：吴来伟 2017-11-27 15:10
// 创建描述：
//
// 修改标识：吴来伟2017-11-27 15:10
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Reflection;
using System.Threading.Tasks;

namespace WorkData.Code.Helpers
{
    public class AsyncHelper
    {
        /// <summary>
        /// Checks if given method is an async method.
        /// </summary>
        /// <param name="method">A method to check</param>
        public static bool IsAsyncMethod(MethodInfo method)
        {
            return (
                method.ReturnType == typeof(Task) ||
                (method.ReturnType.GetTypeInfo().IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
            );
        }
    }
}