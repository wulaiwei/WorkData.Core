// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Util.Common
// 文件名：WorkDataException.cs
// 创建标识：吴来伟 2018-03-27 14:50
// 创建描述：
//
// 修改标识：吴来伟2018-03-27 14:51
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;

#endregion

namespace WorkData.Util.Common.ExceptionExtensions
{
    /// <summary>
    /// WorkDataException
    /// </summary>
    [Serializable]
    public class WorkDataException : Exception
    {
        /// <summary>
        ///     Creates a new <see cref="WorkDataException" /> object.
        /// </summary>
        public WorkDataException()
        {
        }

        /// <summary>
        ///     Creates a new <see cref="WorkDataException" /> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public WorkDataException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Creates a new <see cref="WorkDataException" /> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public WorkDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}