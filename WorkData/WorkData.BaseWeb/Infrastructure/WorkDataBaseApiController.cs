#region

using Microsoft.AspNetCore.Mvc;
using WorkData.Code.ResponseExtensions;

#endregion

namespace WorkData.BaseWeb.Infrastructure
{
    public abstract class WorkDataBaseApiController : WorkDataBaseController
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
            return Ok(serverResponse);
        }
    }
}