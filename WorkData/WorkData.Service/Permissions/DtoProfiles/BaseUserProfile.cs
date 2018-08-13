using WorkData.Code.AutoMappers;
using WorkData.Domain.Permissions.Users;
using WorkData.Service.Permissions.Users.Dto;

namespace WorkData.Service.Permissions.DtoProfiles
{
    public class BaseUserProfile: WorkDataBaseProfile
    {
        protected override void Configure()
        {
            CreateMap<BaseUserInputDto, BaseUser>();
        }
    }
}