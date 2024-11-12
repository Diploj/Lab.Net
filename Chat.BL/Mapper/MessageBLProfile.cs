using AutoMapper;
using Chat.BL.Message.Entities;
using Chat.DataAccess.Entities;

namespace Chat.BL.Mapper;

public class MessageBlProfile : Profile
{
    public MessageBlProfile()
    {
        CreateMap<MessageEntity, MessageModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExternalId));

        CreateMap<CreateMessageModel, MessageEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ExternalId, opt => opt.Ignore())
            .ForMember(dest => dest.ModificationTime, opt => opt.Ignore())
            .ForMember(dest => dest.CreationTime, opt => opt.Ignore());

        CreateMap<UpdateMessageModel, MessageEntity>()
            .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ModificationTime, opt => opt.Ignore());
    }
}