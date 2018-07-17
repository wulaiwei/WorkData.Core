// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：StringExtension.cs
// 创建标识：吴来伟 2018-01-30 9:17
// 创建描述：
//
// 修改标识：吴来伟2018-01-30 9:17
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using System.Text;

namespace WorkData.Code.Extensions
{
    /// <summary>
    /// StringExtension
    /// </summary>
    public static class StringExtension
    {
        ///<summary>
        /// Base 64 Encoding with URL and Filename Safe Alphabet using UTF-8 character set.
        ///</summary>
        ///<param name="str">The origianl string</param>
        ///<returns>The Base64 encoded string</returns>
        public static string Base64ForUrlEncode(this string str)
        {
            byte[] c = Convert.FromBase64String(str);
            return Encoding.Default.GetString(c);
        }

        ///<summary>
        /// Decode Base64 encoded string with URL and Filename Safe Alphabet using UTF-8.
        ///</summary>
        ///<param name="str">Base64 code</param>
        ///<returns>The decoded string.</returns>
        public static string Base64ForUrlDecode(this string str)
        {
            var b = Encoding.Default.GetBytes(str);
            //转成 Base64 形式的 System.String
            return Convert.ToBase64String(b);
        }
    }
}