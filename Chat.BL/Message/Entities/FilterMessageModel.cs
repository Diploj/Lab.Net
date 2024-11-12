using System;

namespace Chat.BL.Message.Entities;

public class FilterMessageModel
{
    public DateTime? SendDate { get; set; } 
    public string? TextPart { get; set; }
    public int? UserId { get; set; }
}