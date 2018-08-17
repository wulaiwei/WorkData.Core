#region 导入名称空间

using Newtonsoft.Json;

#endregion 导入名称空间

namespace WorkData.WeiXin.WeiXin.Model
{
    public class AccessToken
    {
        //{"access_token":"bxIZkBZi0n7zWX1QEULZIAvgzGRDjaQ7o0JopKDJ1TtBEHC1AB8ZbVS2dq8OJvGW8UPt7_YRzTV4oAg1vL8yyA","expires_in":7200}
        [JsonProperty("access_token")]
        public string Token { get; set; } = "";

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; } = 7200;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}