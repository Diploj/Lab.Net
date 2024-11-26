namespace Chat.Service.Controllers.Messages.Entities;

public class UpdateMessageRequest
{
    public int Id { get; set; }
    public DateTime CreationTime { get; set; } 
    public string Text { get; set; }
    public int UserId { get; set; }
}