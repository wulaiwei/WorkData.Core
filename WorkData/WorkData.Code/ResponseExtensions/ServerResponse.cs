// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Util.Common
// 文件名：ServerResponse.cs
// 创建标识：吴来伟 2018-03-28 11:25
// 创建描述：
//
// 修改标识：吴来伟2018-03-28 11:25
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Newtonsoft.Json;
using System.Runtime.Serialization;

#endregion

namespace WorkData.Code.ResponseExtensions
{
    /// <summary>
    ///     接口返回值
    /// </summary>
    [DataContract]
    public class ServerResponse
    {
        /// <summary>
        ///     状态
        /// </summary>
        [DataMember]
        [JsonProperty("status")]
        public bool Status { get; set; }

        /// <summary>
        ///     描述信息
        /// </summary>
        [DataMember]
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    /// <summary>
    ///     响应消息类
    /// </summary>
    [DataContract]
    public class ServerResponse<T> : ServerResponse
    {
        /// <summary>
        ///     业务数据对象
        /// </summary>
        [DataMember]
        [JsonProperty("result")]
        public T Result { get; set; }
    }
}