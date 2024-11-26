using Chat.BL.Message.Entities;

namespace Chat.BL.Message;

public interface IMessageManager
{
    MessageModel CreateMessage(CreateMessageModel model);
    void DeleteMessage(int id);
    MessageModel UpdateMessage(int id, UpdateMessageModel model);
}