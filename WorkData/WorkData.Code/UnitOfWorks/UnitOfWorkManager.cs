// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Infrastructure
// 文件名：UnitOfWorkManager.cs
// 创建标识：吴来伟 2017-11-27 14:28
// 创建描述：
//
// 修改标识：吴来伟2017-11-27 14:28
// 修改描述：
//  ------------------------------------------------------------------------------

using WorkData.Dependency;

namespace WorkData.Code.UnitOfWorks
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        private readonly ICurrentUnitOfWorkProvider _currentUnitOfWorkProvider;
        private readonly IResolver _resolver;

        public UnitOfWorkManager(ICurrentUnitOfWorkProvider currentUnitOfWorkProvider, IResolver resolver)
        {
            _currentUnitOfWorkProvider = currentUnitOfWorkProvider;
            _resolver = resolver;
        }

        /// <summary>
        /// Current
        /// </summary>
        public IActiveUnitOfWork Current => _currentUnitOfWorkProvider.Current;

        /// <summary>
        /// Begin
        /// </summary>
        /// <returns></returns>
        public IUnitOfWorkCompleteHandle Begin()
        {
            var unitOfWork = _resolver.Resolve<IUnitOfWork>();
            //开启事务
            unitOfWork.Begin();
            //设置定位
            _currentUnitOfWorkProvider.Current = unitOfWork;
            return unitOfWork;
        }

        public void Dispose()
        {
        }
    }
}