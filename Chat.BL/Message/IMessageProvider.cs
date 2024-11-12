using Chat.BL.Message.Entities;

namespace Chat.BL.User;

public interface IMessageProvider
{
    IEnumerable<MessageModel> GetUsers(FilterMessageModel? filter = null);
    MessageModel GetUserInfo(int id);
}