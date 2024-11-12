using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.DataAccess.Entities;

[Table("message")]
public class MessageEntity : BaseEntity
{
    public string Text { get; set; }
    public int UserId { get; set; }
    public UserEntity User { get; set; }
}