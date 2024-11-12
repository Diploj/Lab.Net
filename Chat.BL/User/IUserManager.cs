using Chat.BL.User.Entities;

namespace Chat.BL.User;

public interface IUserManager
{
    UserModel CreateUser(CreateUserModel model);
    void DeleteUser(int id);
    UserModel UpdateUser(UpdateUserModel model);
}