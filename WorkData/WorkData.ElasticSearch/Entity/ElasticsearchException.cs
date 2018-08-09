// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.ElasticSearch
// 文件名：ElasticsearchException.cs
// 创建标识：吴来伟 2018-05-02 11:07
// 创建描述：
//
// 修改标识：吴来伟2018-05-02 11:07
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using WorkData.Util.Common.ExceptionExtensions;

namespace WorkData.ElasticSearch.Entity
{
    [Serializable]
    public class ElasticsearchException : WorkDataException
    {
        /// <summary>
        /// Additional information about the exception.
        /// </summary>
        public string Details { get; private set; }

        /// <summary>
        /// An arbitrary error code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public ElasticsearchException()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        public ElasticsearchException(string message)
            : base(message)
        {
        }

        public ElasticsearchException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code">Error code</param>
        /// <param name="message">Exception message</param>
        public ElasticsearchException(int code, string message)
            : this(message)
        {
            Code = code;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="details">Additional information about the exception</param>
        public ElasticsearchException(string message, string details)
            : this(message)
        {
            Details = details;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code">Error code</param>
        /// <param name="message">Exception message</param>
        /// <param name="details">Additional information about the exception</param>
        public ElasticsearchException(int code, string message, string details)
            : this(message, details)
        {
            Code = code;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="details">Additional information about the exception</param>
        /// <param name="innerException">Inner exception</param>
        public ElasticsearchException(string message, string details, Exception innerException)
            : this(message, innerException)
        {
            Details = details;
        }
    }
}