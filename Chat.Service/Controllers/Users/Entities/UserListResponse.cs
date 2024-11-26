namespace Chat.Service.Controllers.Users.Entities;
using Chat.BL.User.Entities;

public class UserListResponse
{
    public List<UserModel> Users { get; set; }
}