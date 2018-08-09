// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Web
// 文件名：WorkDataBaseApiController.cs
// 创建标识：吴来伟 2018-05-28 11:33
// 创建描述：
//
// 修改标识：吴来伟2018-06-11 15:32
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Microsoft.AspNetCore.Mvc;
using WorkData.Code.ResponseExtensions;

#endregion

namespace WorkData.Web.Extensions.Infrastructure
{
    public class WorkDataBaseApiController : WorkDataBaseController
    {
        /// <summary>
        /// AsSuccess
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual IActionResult AsSuccessJson<T>(T data)
        {
            var serverResponse = ResponseProvider.Success(data);
            return Ok(serverResponse);
        }

        /// <summary>
        /// AsError
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual IActionResult AsErrorJson<T>(T data, string message)
        {
            var serverResponse = ResponseProvider.Error(data, message);
            return Ok(serverResponse);
        }

        /// <summary>
        /// AsError
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual IActionResult AsErrorJson(string message)
        {
            var serverResponse = ResponseProvider.Error(default(BaseResponseEmpty), message);
            return BadRequest(serverResponse);
        }
    }
}