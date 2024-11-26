namespace Chat.Service.Controllers.Messages.Entities;

public class SendMessageRequest
{
    public string Text { get; set; }
    public int UserId { get; set; }
}