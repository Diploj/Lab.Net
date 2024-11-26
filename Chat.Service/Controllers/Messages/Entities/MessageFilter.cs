
namespace Chat.Service.Controllers.Messages.Entities;

public class MessageFilter
{
    public DateTime? SendDate { get; set; } 
    public string? TextPart { get; set; }
    public int? UserId { get; set; }
}