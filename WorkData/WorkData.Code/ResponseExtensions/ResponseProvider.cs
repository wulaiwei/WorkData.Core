// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Util.Common
// 文件名：ResponseProvider.cs
// 创建标识：吴来伟 2018-03-28 11:25
// 创建描述：
//
// 修改标识：吴来伟2018-03-28 11:25
// 修改描述：
//  ------------------------------------------------------------------------------

#region

#endregion

#region

#endregion

namespace WorkData.Code.ResponseExtensions
{
    public static class ResponseProvider
    {
        /// <summary>
        ///     响应消息封装类
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public static ServerResponse Success(string msg = null)
        {
            var result = new ServerResponse { Status = true, Message = msg };
            return result;
        }

        /// <summary>
        ///     响应消息封装类
        /// </summary>
        /// <param name="status">状态:0 -成功 其它 失败</param>
        /// <param name="errMsg">消息内容</param>
        /// <returns></returns>
        public static ServerResponse Error(string errMsg, bool status = false)
        {
            var result = new ServerResponse { Status = status, Message = errMsg };
            return result;
        }

        /// <summary>
        ///     响应消息封装类
        /// </summary>
        /// <param name="status">状态:0 -成功 其它 失败</param>
        /// <param name="data"></param>
        /// <param name="errMsg">消息内容</param>
        /// <returns></returns>
        public static ServerResponse<T> Error<T>(T data, string errMsg, bool status = false)
        {
            var result = new ServerResponse<T> { Result = data, Status = status, Message = errMsg };
            return result;
        }

        /// <summary>
        ///     响应消息封装类
        /// </summary>
        /// <param name="data">业务数据</param>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public static ServerResponse<T> Success<T>(T data, string msg = null)
        {
            var result = new ServerResponse<T> { Result = data, Status = true, Message = msg };

            return result;
        }

        /// <summary>
        ///     Http 响应消息封装类
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public static ServerResponse<T> Error<T>(string msg = null)
        {
            var result = new ServerResponse<T> { Result = default(T), Status = false, Message = msg };

            return result;
        }
    }
}