// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Workdata.UnitTest
// 文件名：WorkDataUnitTestSession.cs
// 创建标识：吴来伟 2018-07-26 14:58
// 创建描述：
//  
// 修改标识：吴来伟2018-07-26 15:10
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using WorkData.Code.Sessions;

#endregion

namespace Workdata.UnitTest
{
    public class WorkDataUnitTestSession : WorkDataBaseSession
    {
        public override string UserId => Guid.NewGuid().ToString();
    }
}