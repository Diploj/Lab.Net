using System;

namespace Chat.BL.User.Entities;

public class UpdateUserModel
{
   // public Guid Id { get; set; }
    public DateTime CreationTime { get; set; } 
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public Boolean IsAdmin { get; set; }
}