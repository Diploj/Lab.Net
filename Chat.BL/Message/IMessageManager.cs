using Chat.BL.Message.Entities;

namespace Chat.BL.User;

public interface IMessageManager
{
    MessageModel CreateUser(CreateMessageModel model);
    void DeleteUser(int id);
    MessageModel UpdateUser(UpdateMessageModel model);
}