using AutoMapper;
using UsersList.Contracts.Entities;
using UsersList.Contracts.Users;

namespace UsersList.Utils.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
