using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.DataAccess.Entities;

[Table("ban")]
public class BanEntity: BaseEntity
{
    public string Reason { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public int UserId { get; set; }
    public UserEntity User { get; set; }
}