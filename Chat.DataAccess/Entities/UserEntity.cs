using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Chat.DataAccess.Entities;

public enum Role
{
    Admin,
    User
}

[Table("users")]
public class UserEntity:BaseEntity
{
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public Role Role { get; set; }
    
    public virtual ICollection<MessageEntity> Messages { get; set; }
    public BanEntity? Ban  { get; set; }
}