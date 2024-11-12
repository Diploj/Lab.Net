using System;

namespace Chat.BL.Message.Entities;

public class CreateMessageModel
{
    public string Text { get; set; }
    public int UserId { get; set; }
}