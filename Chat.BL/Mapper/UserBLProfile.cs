using AutoMapper;
using Chat.BL.User.Entities;
using Chat.DataAccess.Entities;

namespace Chat.BL.Mapper;

public class UserBlProfile : Profile
{
    public UserBlProfile()
    {
        CreateMap<UserEntity, UserModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId))
            .ForMember(dest => dest.IsAdmin, opt => opt.MapFrom(src => src.Role==Role.Admin));

        CreateMap<CreateUserModel, UserEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ExternalId, opt => opt.Ignore())
            .ForMember(dest => dest.ModificationTime, opt => opt.Ignore())
            .ForMember(dest => dest.CreationTime, opt => opt.Ignore());

        CreateMap<UpdateUserModel, UserEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ExternalId, opt => opt.Ignore())
            .ForMember(dest => dest.ModificationTime, opt => opt.Ignore())
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.IsAdmin ? Role.Admin : Role.User));
    }
}