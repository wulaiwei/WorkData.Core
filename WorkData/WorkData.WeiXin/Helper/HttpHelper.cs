#region 版权说明

// ----------------------------------------------------------------------------
// Copyright (C) 成都联宇创新科技有限公司 版权所有。
//
//   文件名：HttpUtils.cs
// 功能描述：
// 创建标识：骆智慧 2016/05/26 01:42
//
// 修改标识：骆智慧 2016/05/26 01:44
// 修改描述：
//  ----------------------------------------------------------------------------

#endregion 版权说明

#region 导入名称空间

using System.Text;
using System.Web;
using Microsoft.AspNetCore.Http;

#endregion 导入名称空间

namespace Jwell.Wechat.Common.Helper
{
    public static class HttpHelper
    {
        /// <summary>
        /// 要发送的消息
        /// </summary>
        /// <param name="message"></param>
        public static void SetResponse(string message)
        {
            var response = HttpContext.Current.Response;
            response.Write(message);
            response.Flush();
        }

        /// <summary>
        /// 跳转
        /// </summary>
        /// <param name="url"></param>
        public static void SetResponseRedirect(string url)
        {
            var response = HttpContext.Current.Response;
            //这里是关键，清除在返回前已经设置好的标头信息，这样后面的跳转才不会报错
            response.Clear();

            response.Redirect(url,true);
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ParseUrl(string key)
        {
            var nvcQueryString = HttpContext.Current.Request.QueryString;
            var nameValue = nvcQueryString.Get(key);

            return nameValue;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public static string GetPost()
        {
            var request = HttpContext.Current.Request;
            using (var stream = request.InputStream)
            {
                var buffer = new byte[request.TotalBytes];
                stream.Read(buffer, 0, buffer.Length);
                var requstStr = Encoding.UTF8.GetString(buffer);

                return requstStr;
            }
        }
    }
}