using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Chat.DataAccess.Entities;

[Table("message")]
public class MessageEntity : BaseEntity
{
    public string Text { get; set; }
    public DateTime SendDate { get; set; }
    public Object? Attachment { get; set; }
    
    public int UserId { get; set; }
    public UserEntity User { get; set; }
}