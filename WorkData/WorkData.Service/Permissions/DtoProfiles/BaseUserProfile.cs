using WorkData.Code.AutoMappers;
using WorkData.Domain.Permissions.Users;
using WorkData.Service.Permissions.Users.Dto;

namespace WorkData.Service.Permissions.DtoProfiles
{
    public class BaseUserProfile : WorkDataBaseProfile
    {
        public BaseUserProfile()
        {
            CreateMap<BaseUserInputDto, BaseUser>();
            CreateMap<BaseUser, BaseUserInputDto>();
        }
    }
}