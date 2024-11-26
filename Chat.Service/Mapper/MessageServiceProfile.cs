using AutoMapper;
using Chat.BL.Message.Entities;
using Chat.Service.Controllers.Messages.Entities;

namespace Chat.Service.Mapper;

public class MessageServiceProfile : Profile
{
    public MessageServiceProfile()
    {
        CreateMap<SendMessageRequest, CreateMessageModel>();
        CreateMap<UpdateMessageRequest, UpdateMessageModel>();
        CreateMap<MessageFilter, FilterMessageModel>();
    }
}