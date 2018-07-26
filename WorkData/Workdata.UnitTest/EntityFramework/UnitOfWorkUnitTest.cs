// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Workdata.UnitTest
// 文件名：UnitOfWorkUnitTest.cs
// 创建标识：吴来伟 2018-07-26 10:54
// 创建描述：
//  
// 修改标识：吴来伟2018-07-26 10:54
// 修改描述：
//  ------------------------------------------------------------------------------

using WorkData.Code.UnitOfWorks;
using WorkData.Dependency;
using Xunit;

namespace Workdata.UnitTest.EntityFramework
{
    public class UnitOfWorkUnitTest : BaseUnitTest
    {
        public IUnitOfWorkCompleteHandle UnitOfWorkCompleteHandle { get; set; }
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public UnitOfWorkUnitTest()
        {
            _unitOfWorkManager = IocManager.Instance.Resolve<IUnitOfWorkManager>();
        }

        [Fact]
        public void BeginUnitOfWork()
        {
            UnitOfWorkCompleteHandle = _unitOfWorkManager.Begin();
        }

        [Fact]
        public void ComplateUnitOfWork()
        {
            UnitOfWorkCompleteHandle = _unitOfWorkManager.Begin();
            UnitOfWorkCompleteHandle.Complate();
        }

    }
}