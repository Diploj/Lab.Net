using Chat.BL.Message.Entities;

namespace Chat.Service.Controllers.Messages.Entities;

public class MessageListResponse
{
    public List<MessageModel> Messages { get; set; }
}