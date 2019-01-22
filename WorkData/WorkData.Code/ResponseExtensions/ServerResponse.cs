
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