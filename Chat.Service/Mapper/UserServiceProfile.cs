using AutoMapper;
using Chat.BL.User.Entities;
using Chat.Service.Controllers.Users.Entities;

namespace Chat.Service.Mapper;

public class UserServiceProfile : Profile
{
    public UserServiceProfile()
    {
        CreateMap<RegisterUserRequest, CreateUserModel>();
        CreateMap<UpdateUserRequest, UpdateUserModel>();
        CreateMap<UserFilter, FilterUserModel>();
    }
}