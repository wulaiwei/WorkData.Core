// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：Workdata.UnitTest
// 文件名：RepositoryUnitTest.cs
// 创建标识：吴来伟 2018-07-26 11:02
// 创建描述：
//
// 修改标识：吴来伟2018-07-26 15:00
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using WorkData.Code.Repositories;
using WorkData.Code.Sessions;
using WorkData.Code.UnitOfWorks;
using WorkData.Dependency;
using WorkData.Domain.Permissions.Users;
using Xunit;

#endregion

namespace Workdata.UnitTest.EntityFramework
{
    public class RepositoryUnitTest : BaseUnitTest
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IBaseRepository<BaseUser, string> _baseUserRepository;

        /// <summary>
        ///     WorkDataSession
        /// </summary>
        public RepositoryUnitTest()
        {
            _unitOfWorkManager = IocManager.ServiceLocatorCurrent.GetInstance<IUnitOfWorkManager>();
            _baseUserRepository = IocManager.ServiceLocatorCurrent.GetInstance<IBaseRepository<BaseUser, string>>();
            var workDataSession = IocManager.ServiceLocatorCurrent.GetInstance<IWorkDataSession>();
        }

        [Fact]
        public void Insert()
        {
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                var user = new BaseUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "cessdfa"
                };
                _baseUserRepository.Insert(user);

                unitOfWork.Complate();
            }
        }
    }
}