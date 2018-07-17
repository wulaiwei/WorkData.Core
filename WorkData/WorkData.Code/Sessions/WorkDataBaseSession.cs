// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：WorkDataBaseSession.cs
// 创建标识：吴来伟 2017-12-19 15:15
// 创建描述：
//
// 修改标识：吴来伟2017-12-19 15:15
// 修改描述：
//  ------------------------------------------------------------------------------
namespace WorkData.Code.Sessions
{
    public abstract class WorkDataBaseSession : IWorkDataSession
    {
        public abstract string UserId { get; }
    }
}