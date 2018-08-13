using System.Security.Claims;
using WorkData.Code.Domain;
using WorkData.Code.Repositories;
using WorkData.Code.Sessions;

namespace WorkData.Domain.Permissions.Users
{
    /// <inheritdoc />
    /// <summary>
    /// BaseUserManage
    /// </summary>
    public class BaseUserManage : WorkDataBaseManage
    {
        private readonly IBaseRepository<BaseUser, string> _baseUserRepository;
        public BaseUserManage(IBaseRepository<BaseUser, string> baseUserRepository)
        {
            _baseUserRepository = baseUserRepository;
        }

        /// <summary>
        /// AddBaseUser
        /// </summary>
        /// <param name="baseUser"></param>
        public void AddBaseUser(BaseUser baseUser)
        {
            _baseUserRepository.Insert(baseUser);
        }

        /// <summary>
        /// AddBaseUserMember
        /// </summary>
        /// <param name="baseUserId"></param>
        /// <param name="baseUserMember"></param>
        public void AddBaseUserMember(string baseUserId, BaseUserMember baseUserMember)
        {
            var baseUser = _baseUserRepository.FindBy(baseUserId);
            baseUser.BaseUserMember = baseUserMember;

            _baseUserRepository.Update(baseUser);
        }
    }
}