using Autofac;
using WorkData.Extensions.Modules;
using WorkData.WeiXin.Impl;
using WorkData.WeiXin.Interface;

namespace WorkData.WeiXin
{
    /// <summary>
    /// Wechat
    /// </summary>
    public class WechatModule : WorkDataBaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LocalAuthenticationService>().As<ILocalAuthenticationService>();
        }
    }
}