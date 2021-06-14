using AutoMapper;
using MusicCenter.Application.DTO;
using MusicCenter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Implementation.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();

            CreateMap<UpdateUserDto, User>()
               .ForAllMembers(opt => opt.Condition((dto, user, srcMemb) => srcMemb != null));
        }
    }
}
