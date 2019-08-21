#region NameSpace

using System;
using System.Linq;
using System.Text;

#endregion NameSpace

namespace WorkData.Util.Common.Extensions
{
    /// <summary>
    ///     字符串扩展类
    /// </summary>
    public static class StringExtensions
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

        /// <summary>
        /// SplitString
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <param name="isFirst"></param>
        /// <returns></returns>
        public static string SplitString(this string str, char key, bool isFirst = false)
        {
            var strArray = str.Split(new[] { key }, StringSplitOptions.RemoveEmptyEntries);
            if (strArray.Length <= 0)
                return string.Empty;
            return isFirst ? strArray.FirstOrDefault() : strArray.LastOrDefault();
        }

        /// <summary>
        ///     拆分数组
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string[] BreakUpOptions(this string str, char key)
        {
            var strArray = str.Split(new[] { key }, StringSplitOptions.RemoveEmptyEntries);
            return strArray;
        }

        /// <summary>
        ///     拆分数组
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int[] BreakUpStr(this string str, char key)
        {
            var strArray = str.Split(new[] { key }, StringSplitOptions.RemoveEmptyEntries);
            return Array.ConvertAll(strArray, int.Parse);
        }

        /// <summary>
        /// 构建in  查询字段
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string BuildQueryIn(this string[] array)
        {
            var str = array.Aggregate("", (current, item) => current + $"'{item}',");
            return string.IsNullOrWhiteSpace(str) ? "" : str.Substring(0, str.Length - 1);
        }

        /// <summary>
        /// 构建in  查询字段
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string BuildQueryIn(this long[] array)
        {
            var str = array.Aggregate("", (current, item) => current + $"{item},");
            return string.IsNullOrWhiteSpace(str) ? "" : str.Substring(0, str.Length - 1);
        }

        /// <summary>
        ///     Adds a char to end of given string if it does not ends with the char.
        /// </summary>
        public static DateTime EnsureEndsWith(this string str, string template)
        {
            return Convert.ToDateTime(template);
        }

        /// <summary>
        ///     Dateyyyymmdds the specified date.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public static string ToDateyyyymmdd(this string str)
        {
            var isDate = DateTime.TryParse(str, out DateTime date);
            return !isDate ? string.Empty : date.ToString("yyyyMMdd");
        }

        /// <summary>
        ///     Dateyyyymmdds the specified date.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public static DateTime? ToDate(this string str)
        {
            var isDate = DateTime.TryParse(str, out DateTime date);
            return !isDate ? default(DateTime?) : date;
        }

        /// <summary>
        ///    转成制定格式的时间字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToDateStringyyyymmdd(this string str, string format)
        {
            var isDate = DateTime.TryParse(str, out DateTime date);
            return !isDate ? string.Empty : date.ToString(format);
        }

        /// <summary>
        ///     Dateyyyymmdds the specified date.
        /// </summary>
        /// <param name="dataTime">The string.</param>
        /// <param name="fomart"></param>
        /// <returns></returns>
        public static string ToDateyyyymmdd(this DateTime? dataTime, string fomart = "yyyy-MM-dd HH:mm")
        {
            var isDate = dataTime.HasValue;
            return !isDate ? string.Empty : Convert.ToDateTime(dataTime).ToString(fomart);
        }

        /// <summary>
        ///     Dateyyyymmdds the specified date.
        /// </summary>
        /// <param name="dataTime">The string.</param>
        /// <param name="fomart"></param>
        /// <returns></returns>
        public static string ToDateyyyymmdd(this DateTime dataTime, string fomart = "yyyy-MM-dd HH:mm")
        {
            return dataTime.ToString(fomart);
        }

        public static string DecimaloString(this decimal? str)
        {
            return !str.HasValue ? string.Empty : str.ToString();
        }

        /// <summary>
        ///     将传入的字符串中间部分字符替换成特殊字符
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="startLen">前保留长度</param>
        /// <param name="endLen">尾保留长度</param>
        /// <param name="specialChar">特殊字符</param>
        /// <returns>被特殊字符替换的字符串</returns>
        public static string ReplaceWithSpecialChar(this string str, int startLen = 4, int endLen = 4,
            char specialChar = '*')
        {
            if (str == null)
                return string.Empty;

            var lenth = str.Length - startLen - endLen;
            if (lenth <= 0)
                return str;

            var replaceStr = str.Substring(startLen, lenth);

            var specialStr = string.Empty;

            for (var i = 0; i < replaceStr.Length; i++)
                specialStr += specialChar;

            return str.Replace(replaceStr, specialStr);
        }
    }
}