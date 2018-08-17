using System;
using System.Collections.Generic;
using System.Xml;
using WorkData.WeiXin.WeiXin.Model;

namespace WorkData.WeiXin.WeiXin
{
    /// <summary>
    /// 微信企业服务
    /// </summary>
    public interface IWeiXinQiYeService
    {
        /// <summary>
        /// 获取访问令牌完成事件
        /// </summary>
        event WeiXinEventHandler GetAccessTokenCompleted;

        /// <summary>
        /// （回调模式,未解密）准备解密用户请求事件
        /// </summary>
        event WeiXinEventHandler DecryptReady;

        /// <summary>
        /// （回调模式，已解密）用户请求完成解密事件
        /// </summary>
        event WeiXinEventHandler DecryptCompleted;

        /// <summary>
        /// （回调模式）响应消息准备加密事件
        /// </summary>
        event WeiXinEventHandler EncryptReady;

        /// <summary>
        /// （回调模式）响应消息完成加密事件
        /// </summary>
        event WeiXinEventHandler EncryptCompleted;

        /// <summary>
        /// 推送消息响应完成
        /// </summary>
        event WeiXinEventHandler PushMessageCompleted;

        /// <summary>
        /// 获取用户信息
        /// </summary>
        event WeiXinEventHandler OAuth2GetUserInfoCompleted;

        /// <summary>
        /// 验证回调地址(回调模式)
        /// </summary>
        void VerifyCallBackUrl();

        /// <summary>
        /// 回调处理程序
        /// <para>
        /// callback 返回Null或 XML格式字符串
        /// </para>
        /// </summary>
        /// <param name="callback">回调代理（返回Null或 XML格式字符串）</param>
        void CallbackHandle(Func<XmlDocument, string> callback);

        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="agentId">企业应用的id，整型。可在应用的设置页面查看</param>
        /// <param name="touser"> 成员ID列表（消息接收者，多个接收者用‘|’分隔，最多支持1000个）。特殊情况：指定为@all，则向关注该企业应用的全部成员发送 </param>
        /// <param name="toparty">部门ID列表，多个接收者用‘|’分隔，最多支持100个。当touser为@all时忽略本参数</param>
        /// <param name="totag">标签ID列表，多个接收者用‘|’分隔。当touser为@all时忽略本参数</param>
        /// <param name="articles">
        ///     <para>最多10条</para>
        /// </param>
        void PushMessage(string agentId, string touser, string toparty, string totag, List<WeiXinArticle> articles);

        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="json"></param>
        void PushMessage(string json);

        /// <summary>
        /// 获取成员 json 格式
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>
        /// <![CDATA[
        /// {
        ///"errcode": 0,
        ///"errmsg": "ok",
        ///"userid": "zhangsan",
        ///"name": "李四",
        ///"department": [1, 2],
        ///"position": "后台工程师",
        ///"mobile": "15913215421",
        ///"gender": "1",
        ///"email": "zhangsan@gzdev.com",
        ///"weixinid": "lisifordev",
        ///"avatar": "http://wx.qlogo.cn/mmopen/ajNVdqHZLLA3WJ6DSZUfiakYe37PKnQhBIeOQBO4czqrnZDS79FH5Wm5m4X69TBicnHFlhiafvDwklOpZeXYQQ2icg/0",
        ///"status": 1,
        ///"extattr": {"attrs":[{"name":"爱好","value":"旅游"},{"name":"卡号","value":"1234567234"}]}
        ///}
        /// ]]>
        /// </returns>
        string GetJsonForMember(string userId);

        /// <summary>
        /// 获取企业信息 Json 格式
        /// <![CDATA[
        /// {
        ///   "errcode":"0",
        ///   "errmsg":"ok" ,
        ///   "agentid":"1" ,
        ///   "name":"NAME" ,
        ///   "square_logo_url":"xxxxxxxx" ,
        ///   "round_logo_url":"yyyyyyyy" ,
        ///   "description":"desc" ,
        ///   "allow_userinfos":{
        ///       "user":[
        ///             {
        ///                 "userid":"id1",
        ///                 "status":"1"
        ///             },
        ///             {
        ///                 "userid":"id2",
        ///                 "status":"1"
        ///             },
        ///             {
        ///                 "userid":"id3",
        ///                 "status":"1"
        ///             }
        ///              ]
        ///    },
        ///   "allow_partys":{
        ///       "partyid": [1]
        ///    },
        ///   "allow_tags":{
        ///       "tagid": [1,2,3]
        ///    }
        ///   "close":0 ,
        ///   "redirect_domain":"www.qq.com",
        ///   "report_location_flag":0,
        ///   "isreportuser":0,
        ///   "isreportenter":0,
        ///   "type":1
        ///}
        /// ]]>
        /// </summary>
        /// <param name="agentId"></param>
        /// <returns></returns>
        string GetJsonForEnterpriseInfo(string agentId);

        string GetUserId(string code);
    }
}