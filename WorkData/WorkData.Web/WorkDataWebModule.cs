// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Web
// 文件名：WorkDataWebModule.cs
// 创建标识：吴来伟 2018-06-11 10:40
// 创建描述：
//
// 修改标识：吴来伟2018-06-11 10:40
// 修改描述：
//  ------------------------------------------------------------------------------

using Autofac;
using Microsoft.AspNetCore.Identity;
using WorkData.Domain.Permissions.Users;
using WorkData.Extensions.Modules;

namespace WorkData.Web
{
    public class WorkDataWebModule : WorkDataBaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SignInManager<BaseUser>>()
                .AsSelf().InstancePerRequest();
        }
    }
}