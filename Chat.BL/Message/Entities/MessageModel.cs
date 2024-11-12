using System;

namespace Chat.BL.Message.Entities;

public class MessageModel
{
    public Guid Id { get; set; } 
    public DateTime ModificationTime { get; set; } 
    public DateTime CreationTime { get; set; } 
    public string Text { get; set; }
    public int UserId { get; set; }
}