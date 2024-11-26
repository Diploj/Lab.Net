
namespace Chat.Service.Controllers.Users.Entities;

public class UpdateUserRequest
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Role { get; set; }
}