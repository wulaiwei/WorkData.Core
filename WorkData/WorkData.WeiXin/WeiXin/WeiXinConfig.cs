using System;
using Newtonsoft.Json;
using ServiceStack;
using WorkData.WeiXin.WeiXin.Model;

namespace WorkData.WeiXin.WeiXin
{
    /// <summary>
    /// 微信配置
    /// </summary>
    public class WeiXinConfig
    {
        private static AccessToken _accessToken = new AccessToken { Token = "", ExpiresIn = 7200 };
        private DateTime _accessTokenModifyTime = DateTime.Now;

        internal event WeiXinEventHandler CompletedGetAccessToken;

        /// <summary>
        /// 应用ID
        /// </summary>
        public string AgentId { get; }

        /// <summary>
        /// 公众平台上设置的令牌
        /// </summary>
        public string Token { get; }

        /// <summary>
        /// 公众平台上设置的CorpId
        /// </summary>
        public string CorpId { get; }

        /// <summary>
        /// 公司秘钥
        /// </summary>
        public string CorpSecret { get; }

        /// <summary>
        /// 公众平台上设置的 EncodingAesKey
        /// </summary>
        public string EncodingAesKey { get; }

        public WeiXinConfig(string agentId, string token, string corpId, string corpSecret, string encodingAesKey)
        {
            AgentId = agentId;
            Token = token;
            CorpId = corpId;
            EncodingAesKey = encodingAesKey;
            CorpSecret = corpSecret;
        }

        /// <summary>
        /// 获取企业信息
        /// </summary>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public string GetQiYeInfoUrl(string agentId)
        {
            CheckAccessToken();
            return $"https://qyapi.weixin.qq.com/cgi-bin/agent/get?access_token={_accessToken.Token}&agentid={agentId}";
        }

        /// <summary>
        /// 获取用户信息 OAth2
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetUserInfoUrl(string code)
        {
            CheckAccessToken();
            return $"https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token={_accessToken.Token}&code={code}";
        }

        /// <summary>
        /// 检查访问令牌
        /// </summary>
        private void CheckAccessToken()
        {
            var accessTokenLifeTime = (DateTime.Now - _accessTokenModifyTime).TotalSeconds;
            var accessTokenExpire = accessTokenLifeTime > 7200;
            if (accessTokenExpire || string.IsNullOrEmpty(_accessToken.Token))
            {
                var getAccessTokenUrl = GetAccessTokenUrl();
                var accessTokenJson = getAccessTokenUrl.GetStringFromUrl();
                CompletedGetAccessToken?.Invoke(this, new WeiXinEventArgs { WeiXinData = accessTokenJson });
                if (accessTokenJson.Contains("errorcode"))
                {
                    throw new ArgumentException(accessTokenJson);
                }

                _accessToken = JsonConvert.DeserializeObject<AccessToken>(accessTokenJson);
            }

            _accessTokenModifyTime = DateTime.Now;
        }

        #region URL

        /// <summary>
        /// 访问令牌URL
        /// </summary>
        public string GetAccessTokenUrl()
        {
            return $"https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={CorpId}&corpsecret={CorpSecret}";
        }

        /// <summary>
        /// 消息推送URL
        /// </summary>
        public string GetPushMessageUrl()
        {
            CheckAccessToken();
            return $"https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={_accessToken.Token}";
        }

        /// <summary>
        /// 获取成员
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetMemberUrl(string userId)
        {
            CheckAccessToken();
            return $"https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token={_accessToken.Token}&userid={userId}";
        }

        /// <summary>
        /// 部门成员URL
        /// </summary>
        public string GetDepartmentMemberUrl()
        {
            CheckAccessToken();
            return $"https://qyapi.weixin.qq.com/cgi-bin/user/simplelist?access_token={_accessToken.Token}";
        }

        #endregion URL
    }
}