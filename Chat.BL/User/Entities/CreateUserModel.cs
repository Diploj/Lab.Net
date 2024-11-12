using System;

namespace Chat.BL.User.Entities;

public class CreateUserModel
{
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}