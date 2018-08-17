using System;
using System.ComponentModel;

namespace WorkData.WeiXin.WeiXin
{
    public enum ReturnCode
    {
        [Description("未知的错误码")]
        C999Negative = -999,

        #region 加密认证部分

        [Description("签名验证错误")]
        C40001Negative = -40001,

        [Description("xml解析失败")]
        C40002Negative = -40002,

        [Description("sha加密生成签名失败")]
        C40003Negative = -40003,

        [Description("AESKey 非法")]
        C40004Negative = -40004,

        [Description("corpid 校验错误")]
        C40005Negative = -40005,

        [Description("AES 加密失败")]
        C40006Negative = -40006,

        [Description("AES 解密失败")]
        C40007Negative = -40007,

        [Description("解密后得到的buffer非法")]
        C40008Negative = -40008,

        [Description("base64加密失败")]
        C40009Negative = -40009,

        [Description("base64解密失败")]
        C40010Negative = -40010,

        [Description("生成xml失败")]
        C40011Negative = -40011,

        #endregion 加密认证部分

        [Description("系统繁忙")]
        C1Negative = -1,

        [Description("请求成功")]
        C0 = 0,

        #region 全局返回码部分

        [Description("获取access_token时Secret错误，或者access_token无效")]
        C40001 = 40001,

        [Description("不合法的凭证类型")]
        C40002 = 40002,

        [Description("不合法的UserID")]
        C40003 = 40003,

        [Description("不合法的媒体文件类型")]
        C40004 = 40004,

        [Description("不合法的文件类型")]
        C40005 = 40005,

        [Description("不合法的文件大小")]
        C40006 = 40006,

        [Description("不合法的媒体文件id")]
        C40007 = 40007,

        [Description("不合法的消息类型")]
        C40008 = 40008,

        [Description("不合法的corpid")]
        C40013 = 40013,

        [Description("不合法的access_token")]
        C40014 = 40014,

        [Description("不合法的菜单类型")]
        C40015 = 40015,

        [Description("不合法的按钮个数")]
        C40016 = 40016,

        [Description("不合法的按钮类型")]
        C40017 = 40017,

        [Description("不合法的按钮名字长度")]
        C40018 = 40018,

        [Description("不合法的按钮KEY长度")]
        C40019 = 40019,

        [Description("不合法的按钮URL长度")]
        C40020 = 40020,

        [Description("不合法的菜单版本号")]
        C40021 = 40021,

        [Description("不合法的子菜单级数")]
        C40022 = 40022,

        [Description("不合法的子菜单按钮个数")]
        C40023 = 40023,

        [Description("不合法的子菜单按钮类型")]
        C40024 = 40024,

        [Description("不合法的子菜单按钮名字长度")]
        C40025 = 40025,

        [Description("不合法的子菜单按钮KEY长度")]
        C40026 = 40026,

        [Description("不合法的子菜单按钮URL长度")]
        C40027 = 40027,

        [Description("不合法的自定义菜单使用成员")]
        C40028 = 40028,

        [Description("不合法的oauth_code")]
        C40029 = 40029,

        [Description("不合法的UserID列表")]
        C40031 = 40031,

        [Description("不合法的UserID列表长度")]
        C40032 = 40032,

        [Description("不合法的请求字符，不能包含\\uxxxx格式的字符")]
        C40033 = 40033,

        [Description("不合法的参数")]
        C40035 = 40035,

        [Description("不合法的请求格式")]
        C40038 = 40038,

        [Description("不合法的URL长度")]
        C40039 = 40039,

        [Description("不合法的插件token")]
        C40040 = 40040,

        [Description("不合法的插件id")]
        C40041 = 40041,

        [Description("不合法的插件会话")]
        C40042 = 40042,

        [Description("url中包含不合法domain")]
        C40048 = 40048,

        [Description("不合法的子菜单url域名")]
        C40054 = 40054,

        [Description("不合法的按钮url域名")]
        C40055 = 40055,

        [Description("不合法的agentid")]
        C40056 = 40056,

        [Description("不合法的callbackurl或者callbackurl验证失败")]
        C40057 = 40057,

        [Description("不合法的红包参数")]
        C40058 = 40058,

        [Description("不合法的上报地理位置标志位")]
        C40059 = 40059,

        [Description("设置上报地理位置标志位时没有设置callbackurl")]
        C40060 = 40060,

        [Description("设置应用头像失败")]
        C40061 = 40061,

        [Description("不合法的应用模式")]
        C40062 = 40062,

        [Description("参数为空")]
        C40063 = 40063,

        [Description("管理组名字已存在")]
        C40064 = 40064,

        [Description("不合法的管理组名字长度")]
        C40065 = 40065,

        [Description("不合法的部门列表")]
        C40066 = 40066,

        [Description("标题长度不合法")]
        C40067 = 40067,

        [Description("不合法的标签ID")]
        C40068 = 40068,

        [Description("不合法的标签ID列表")]
        C40069 = 40069,

        [Description("列表中所有标签（成员）ID都不合法")]
        C40070 = 40070,

        [Description("不合法的标签名字，标签名字已经存在")]
        C40071 = 40071,

        [Description("不合法的标签名字长度")]
        C40072 = 40072,

        [Description("不合法的openid")]
        C40073 = 40073,

        [Description("news消息不支持指定为高保密消息")]
        C40074 = 40074,

        [Description("不合法的预授权码")]
        C40077 = 40077,

        [Description("不合法的临时授权码")]
        C40078 = 40078,

        [Description("不合法的授权信息")]
        C40079 = 40079,

        [Description("不合法的suitesecret")]
        C40080 = 40080,

        [Description("不合法的suitetoken")]
        C40082 = 40082,

        [Description("不合法的suiteid")]
        C40083 = 40083,

        [Description("不合法的永久授权码")]
        C40084 = 40084,

        [Description("不合法的suiteticket")]
        C40085 = 40085,

        [Description("不合法的第三方应用appid")]
        C40086 = 40086,

        [Description("导入文件存在不合法的内容")]
        C40092 = 40092,

        [Description("不合法的跳转target")]
        C40093 = 40093,

        [Description("不合法的URL")]
        C40094 = 40094,

        [Description("缺少access_token参数")]
        C41001 = 41001,

        [Description("缺少corpid参数")]
        C41002 = 41002,

        [Description("缺少refresh_token参数")]
        C41003 = 41003,

        [Description("缺少secret参数")]
        C41004 = 41004,

        [Description("缺少多媒体文件数据")]
        C41005 = 41005,

        [Description("缺少media_id参数")]
        C41006 = 41006,

        [Description("缺少子菜单数据")]
        C41007 = 41007,

        [Description("缺少oauth code")]
        C41008 = 41008,

        [Description("缺少UserID")]
        C41009 = 41009,

        [Description("缺少url")]
        C41010 = 41010,

        [Description("缺少agentid")]
        C41011 = 41011,

        [Description("缺少应用头像mediaid")]
        C41012 = 41012,

        [Description("缺少应用名字")]
        C41013 = 41013,

        [Description("缺少应用描述")]
        C41014 = 41014,

        [Description("缺少Content")]
        C41015 = 41015,

        [Description("缺少标题")]
        C41016 = 41016,

        [Description("缺少标签ID")]
        C41017 = 41017,

        [Description("缺少标签名字")]
        C41018 = 41018,

        [Description("缺少suiteid")]
        C41021 = 41021,

        [Description("缺少suitetoken")]
        C41022 = 41022,

        [Description("缺少suiteticket")]
        C41023 = 41023,

        [Description("缺少suitesecret")]
        C41024 = 41024,

        [Description("缺少永久授权码")]
        C41025 = 41025,

        [Description("缺少login_ticket")]
        C41034 = 41034,

        [Description("缺少跳转target")]
        C41035 = 41035,

        [Description("access_token超时")]
        C42001 = 42001,

        [Description("refresh_token超时")]
        C42002 = 42002,

        [Description("oauth_code超时")]
        C42003 = 42003,

        [Description("插件token超时")]
        C42004 = 42004,

        [Description("预授权码失效")]
        C42007 = 42007,

        [Description("临时授权码失效")]
        C42008 = 42008,

        [Description("suitetoken失效")]
        C42009 = 42009,

        [Description("需要GET请求")]
        C43001 = 43001,

        [Description("需要POST请求")]
        C43002 = 43002,

        [Description("需要HTTPS")]
        C43003 = 43003,

        [Description("需要成员已关注")]
        C43004 = 43004,

        [Description("需要好友关系")]
        C43005 = 43005,

        [Description("需要订阅")]
        C43006 = 43006,

        [Description("需要授权")]
        C43007 = 43007,

        [Description("需要支付授权")]
        C43008 = 43008,

        [Description("需要处于回调模式")]
        C43010 = 43010,

        [Description("需要企业授权")]
        C43011 = 43011,

        [Description("应用对成员不可见")]
        C43013 = 43013,

        [Description("多媒体文件为空")]
        C44001 = 44001,

        [Description("POST的数据包为空")]
        C44002 = 44002,

        [Description("图文消息内容为空")]
        C44003 = 44003,

        [Description("文本消息内容为空")]
        C44004 = 44004,

        [Description("多媒体文件大小超过限制")]
        C45001 = 45001,

        [Description("消息内容大小超过限制")]
        C45002 = 45002,

        [Description("标题大小超过限制")]
        C45003 = 45003,

        [Description("描述大小超过限制")]
        C45004 = 45004,

        [Description("链接长度超过限制")]
        C45005 = 45005,

        [Description("图片链接长度超过限制")]
        C45006 = 45006,

        [Description("语音播放时间超过限制")]
        C45007 = 45007,

        [Description("图文消息的文章数量不能超过10条")]
        C45008 = 45008,

        [Description("接口调用超过限制")]
        C45009 = 45009,

        [Description("创建菜单个数超过限制")]
        C45010 = 45010,

        [Description("回复时间超过限制")]
        C45015 = 45015,

        [Description("系统分组，不允许修改")]
        C45016 = 45016,

        [Description("分组名字过长")]
        C45017 = 45017,

        [Description("分组数量超过上限")]
        C45018 = 45018,

        [Description("应用名字长度不合法，合法长度为2-16个字")]
        C45022 = 45022,

        [Description("账号数量超过上限")]
        C45024 = 45024,

        [Description("同一个成员每周只能邀请一次")]
        C45025 = 45025,

        [Description("触发删除用户数的保护")]
        C45026 = 45026,

        [Description("mpnews每天只能发送100次")]
        C45027 = 45027,

        [Description("素材数量超过上限")]
        C45028 = 45028,

        [Description("media_id对该应用不可见")]
        C45029 = 45029,

        [Description("作者名字长度超过限制")]
        C45032 = 45032,

        [Description("不存在媒体数据")]
        C46001 = 46001,

        [Description("不存在的菜单版本")]
        C46002 = 46002,

        [Description("不存在的菜单数据")]
        C46003 = 46003,

        [Description("不存在的成员")]
        C46004 = 46004,

        [Description("解析JSON/XML内容错误")]
        C47001 = 47001,

        [Description("Api未授权")]
        C48001 = 48001,

        [Description("Api禁用(一般是管理组类型与Api不匹配，例如普通管理组调用会话服务的Api)")]
        C48002 = 48002,

        [Description("suitetoken无效")]
        C48003 = 48003,

        [Description("授权关系无效")]
        C48004 = 48004,

        [Description("Api已废弃")]
        C48005 = 48005,

        [Description("redirect_uri未授权")]
        C50001 = 50001,

        [Description("成员不在权限范围")]
        C50002 = 50002,

        [Description("应用已停用")]
        C50003 = 50003,

        [Description("成员状态不正确，需要成员为企业验证中状态")]
        C50004 = 50004,

        [Description("企业已禁用")]
        C50005 = 50005,

        [Description("部门长度不符合限制")]
        C60001 = 60001,

        [Description("部门层级深度超过限制")]
        C60002 = 60002,

        [Description("部门不存在")]
        C60003 = 60003,

        [Description("父亲部门不存在")]
        C60004 = 60004,

        [Description("不允许删除有成员的部门")]
        C60005 = 60005,

        [Description("不允许删除有子部门的部门")]
        C60006 = 60006,

        [Description("不允许删除根部门")]
        C60007 = 60007,

        [Description("部门名称已存在")]
        C60008 = 60008,

        [Description("部门名称含有非法字符")]
        C60009 = 60009,

        [Description("部门存在循环关系")]
        C60010 = 60010,

        [Description("管理组权限不足，（user/department/agent）无权限")]
        C60011 = 60011,

        [Description("不允许删除默认应用")]
        C60012 = 60012,

        [Description("不允许关闭应用")]
        C60013 = 60013,

        [Description("不允许开启应用")]
        C60014 = 60014,

        [Description("不允许修改默认应用可见范围")]
        C60015 = 60015,

        [Description("不允许删除存在成员的标签")]
        C60016 = 60016,

        [Description("不允许设置企业")]
        C60017 = 60017,

        [Description("不允许设置应用地理位置上报开关")]
        C60019 = 60019,

        [Description("访问ip不在白名单之中")]
        C60020 = 60020,

        [Description("主页型应用不支持的消息类型")]
        C60025 = 60025,

        [Description("不支持第三方修改主页型应用字段")]
        C60027 = 60027,

        [Description("应用已授权予第三方，不允许通过接口修改主页url")]
        C60028 = 60028,

        [Description("应用已授权予第三方，不允许通过接口修改可信域名")]
        C60029 = 60029,

        [Description("UserID已存在")]
        C60102 = 60102,

        [Description("手机号码不合法")]
        C60103 = 60103,

        [Description("手机号码已存在")]
        C60104 = 60104,

        [Description("邮箱不合法")]
        C60105 = 60105,

        [Description("邮箱已存在")]
        C60106 = 60106,

        [Description("微信号不合法")]
        C60107 = 60107,

        [Description("微信号已存在")]
        C60108 = 60108,

        [Description("QQ号已存在")]
        C60109 = 60109,

        [Description("用户同时归属部门超过20个")]
        C60110 = 60110,

        [Description("UserID不存在")]
        C60111 = 60111,

        [Description("成员姓名不合法")]
        C60112 = 60112,

        [Description("身份认证信息（微信号/手机/邮箱）不能同时为空")]
        C60113 = 60113,

        [Description("性别不合法")]
        C60114 = 60114,

        [Description("已关注成员微信不能修改")]
        C60115 = 60115,

        [Description("扩展属性已存在")]
        C60116 = 60116,

        [Description("成员无有效邀请字段，详情参考(邀请成员关注)的接口说明")]
        C60118 = 60118,

        [Description("成员已关注")]
        C60119 = 60119,

        [Description("成员已禁用")]
        C60120 = 60120,

        [Description("找不到该成员")]
        C60121 = 60121,

        [Description("邮箱已被外部管理员使用")]
        C60122 = 60122,

        [Description("无效的部门id")]
        C60123 = 60123,

        [Description("无效的父部门id")]
        C60124 = 60124,

        [Description("非法部门名字，长度超过限制、重名等")]
        C60125 = 60125,

        [Description("创建部门失败")]
        C60126 = 60126,

        [Description("缺少部门id")]
        C60127 = 60127,

        [Description("字段不合法，可能存在主键冲突或者格式错误")]
        C60128 = 60128,

        [Description("用户设置了拒绝邀请")]
        C60129 = 60129,

        [Description("可信域名不匹配，或者可信域名没有IPC备案（后续将不能在该域名下正常使用jssdk）")]
        C80001 = 80001,

        [Description("邀请额度已用完")]
        C81003 = 81003,

        [Description("部门数量超过上限")]
        C81004 = 81004,

        [Description("发送消息或者邀请的参数全部为空或者全部不合法")]
        C82001 = 82001,

        [Description("不合法的PartyID列表长度")]
        C82002 = 82002,

        [Description("不合法的TagID列表长度")]
        C82003 = 82003,

        [Description("微信版本号过低")]
        C82004 = 82004,

        [Description("包含不合法的词语")]
        C85002 = 85002,

        [Description("不合法的会话ID")]
        C86001 = 86001,

        [Description("不存在的会话ID")]
        C86003 = 86003,

        [Description("不合法的会话名")]
        C86004 = 86004,

        [Description("不合法的会话管理员")]
        C86005 = 86005,

        [Description("不合法的成员列表大小")]
        C86006 = 86006,

        [Description("不存在的成员")]
        C86007 = 86007,

        [Description("需要会话管理员权限")]
        C86101 = 86101,

        [Description("缺少会话ID")]
        C86201 = 86201,

        [Description("缺少会话名")]
        C86202 = 86202,

        [Description("缺少会话管理员")]
        C86203 = 86203,

        [Description("缺少成员")]
        C86204 = 86204,

        [Description("非法的会话ID长度")]
        C86205 = 86205,

        [Description("非法的会话ID数值")]
        C86206 = 86206,

        [Description("会话管理员不在用户列表中")]
        C86207 = 86207,

        [Description("消息服务未开启")]
        C86208 = 86208,

        [Description("缺少操作者")]
        C86209 = 86209,

        [Description("缺少会话参数")]
        C86210 = 86210,

        [Description("缺少会话类型（单聊或者群聊）")]
        C86211 = 86211,

        [Description("缺少发件人")]
        C86213 = 86213,

        [Description("非法的会话类型")]
        C86214 = 86214,

        [Description("会话已存在")]
        C86215 = 86215,

        [Description("非法会话成员")]
        C86216 = 86216,

        [Description("会话操作者不在成员列表中")]
        C86217 = 86217,

        [Description("非法会话发件人")]
        C86218 = 86218,

        [Description("非法会话收件人")]
        C86219 = 86219,

        [Description("非法会话操作者")]
        C86220 = 86220,

        [Description("单聊模式下，发件人与收件人不能为同一人")]
        C86221 = 86221,

        [Description("不允许消息服务访问的API")]
        C86222 = 86222,

        [Description("不合法的消息类型")]
        C86304 = 86304,

        [Description("客服服务未启用")]
        C86305 = 86305,

        [Description("缺少发送人")]
        C86306 = 86306,

        [Description("缺少发送人类型")]
        C86307 = 86307,

        [Description("缺少发送人id")]
        C86308 = 86308,

        [Description("缺少接收人")]
        C86309 = 86309,

        [Description("缺少接收人类型")]
        C86310 = 86310,

        [Description("缺少接收人id")]
        C86311 = 86311,

        [Description("缺少消息类型")]
        C86312 = 86312,

        [Description("缺少客服，发送人或接收人类型，必须有一个为kf")]
        C86313 = 86313,

        [Description("客服不唯一，发送人或接收人类型，必须只有一个为kf")]
        C86314 = 86314,

        [Description("不合法的发送人类型")]
        C86315 = 86315,

        [Description("不合法的发送人id。Userid不存在、openid不存在、kf不存在")]
        C86316 = 86316,

        [Description("不合法的接收人类型")]
        C86317 = 86317,

        [Description("不合法的接收人id。Userid不存在、openid不存在、kf不存在")]
        C86318 = 86318,

        [Description("不合法的客服，kf不在客服列表中")]
        C86319 = 86319,

        [Description("不合法的客服类型")]
        C86320 = 86320,

        [Description("未认证摇一摇周边")]
        C90001 = 90001,

        [Description("缺少摇一摇周边ticket参数")]
        C90002 = 90002,

        [Description("摇一摇周边ticket参数不合法")]
        C90003 = 90003,

        [Description("摇一摇周边ticket过期")]
        C90004 = 90004,

        [Description("未开启摇一摇周边服务")]
        C90005 = 90005

        #endregion 全局返回码部分
    }

    public static class ReturnCodeExtend
    {
        public static ReturnCode GetReturnCode(dynamic value)
        {
            try
            {
                var valueInt = Convert.ToInt32(value);
                var result = (ReturnCode)Enum.ToObject(typeof(ReturnCode), valueInt);
                return result;
            }
            catch
            {
                throw new WeiXinException(ReturnCode.C999Negative);
            }
        }

        public static string GetDescription(this ReturnCode enumValue)
        {
            var enumStr = enumValue.ToString();
            var field = enumValue.GetType().GetField(enumStr);
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length == 0)
            {
                return enumStr;
            }

            var descAttr = (DescriptionAttribute)attributes[0];
            return descAttr.Description;
        }
    }
}