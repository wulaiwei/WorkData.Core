// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：Workdata.UnitTest
// 文件名：TypeFinderUnitTest.cs
// 创建标识：吴来伟 2018-07-26 9:38
// 创建描述：
//
// 修改标识：吴来伟2018-07-26 9:38
// 修改描述：
//  ------------------------------------------------------------------------------

using WorkData.Dependency;
using WorkData.Extensions.TypeFinders;
using Xunit;

namespace Workdata.UnitTest.TypeFinders
{
    public class TypeFinderUnitTest : BaseUnitTest
    {
        private readonly ITypeFinder _typeFinder;

        public TypeFinderUnitTest()
        {
            _typeFinder = IocManager.ServiceLocatorCurrent.GetInstance<ITypeFinder>();
        }

        [Fact]
        public void ResolveTypeFinder()
        {
            Assert.Equal(typeof(WebAppTypeFinder), _typeFinder.GetType());
        }
    }
}