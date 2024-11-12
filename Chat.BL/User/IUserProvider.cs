using Chat.BL.User.Entities;

namespace Chat.BL.User;

public interface IUserProvider
{
    IEnumerable<UserModel> GetUsers(FilterUserModel? filter = null);
    UserModel GetUserInfo(int id);
}