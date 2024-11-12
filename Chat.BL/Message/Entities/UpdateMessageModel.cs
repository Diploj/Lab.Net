using System;

namespace Chat.BL.Message.Entities;

public class UpdateMessageModel
{
    public Guid Id { get; set; }
    public DateTime CreationTime { get; set; } 
    public string Text { get; set; }
    public int UserId { get; set; }
}