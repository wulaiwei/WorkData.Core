// ------------------------------------------------------------------------------
// Copyright  成都积微物联电子商务有限公司 版权所有。 
// 项目名：Jwell.Wechat.Common 
// 文件名：WechatModule.cs
// 创建标识：吴来伟 2017-03-16
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using Autofac;
using Jwell.Wechat.Common;
using WorkData.Extensions.Modules;
using WorkData.WeiXin.Interface;

namespace WorkData.WeiXin
{
    /// <summary>
    /// Wechat layer module of the Jwell.Wechat.Common
    /// </summary>
    public class WechatModule : WorkDataBaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LocalAuthenticationService>().As<ILocalAuthenticationService>();
        }
    }
}