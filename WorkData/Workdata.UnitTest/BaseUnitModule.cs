// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Workdata.UnitTest
// 文件名：BaseUnitModule.cs
// 创建标识：吴来伟 2018-07-25 21:39
// 创建描述：
//  
// 修改标识：吴来伟2018-07-26 15:00
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Autofac;
using WorkData.Code.Sessions;
using WorkData.Extensions.Modules;

#endregion

namespace Workdata.UnitTest
{
    /// <summary>
    ///     BaseUnitModule
    /// </summary>
    public class BaseUnitModule : WorkDataBaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WorkDataUnitTestSession>()
                .As<IWorkDataSession>();
        }
    }
}