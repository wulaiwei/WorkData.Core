

using System;
using Jwell.Wechat.Common.Helper;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Menu;

namespace WorkData.WeiXin.Helper
{
    public class WeChatHelper
    {

        /// <summary>
        /// _accessToken
        /// </summary>
        private static string _accessToken;

        public WeChatHelper(string appId, string corpSecret)
        {
            _accessToken = ToolHelper.GetAccessToken(appId, corpSecret);
        }

        /// <summary>
        /// 获取用户基础信息
        /// </summary>
        /// <param name="openId"></param>
        public WeixinUserInfoResult GetUser(string openId)
        {
            return CommonApi.GetUserInfo(_accessToken, openId);
        }

        #region Menu
        /// <summary>
        /// 获取Menu
        /// </summary>
        /// <returns></returns>
        public GetMenuResult GetMenuList()
        {
            try
            {
                var query = CommonApi.GetMenu(_accessToken);
                return query;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 保存Menu
        /// </summary>
        /// <param name="buttonGroup"></param>
        /// <returns></returns>
        public WxJsonResult SaveMenu(ButtonGroup buttonGroup)
        {
            var result = CommonApi.CreateMenu(_accessToken, buttonGroup);

            return result;
        }

        /// <summary>
        /// 删除Menu
        /// </summary>
        /// <returns></returns>
        public static WxJsonResult Remove()
        {
            var result = CommonApi.DeleteMenu(_accessToken);

            return result;
        } 
        #endregion



    }
}