using Chat.BL.Message.Entities;

namespace Chat.BL.Message;

public interface IMessageProvider
{
    IEnumerable<MessageModel> GetMessages(FilterMessageModel? filter = null);
    MessageModel GetMessageInfo(int id);
}