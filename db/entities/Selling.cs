using System.ComponentModel.DataAnnotations;

namespace Entity_framework_cli.db.entities;

public class Selling
{
    [Key]
    public int Id { get; set; }
    [Required]
    public PropertyObject PropertyObject { get; set; }
    public DateTime SellDate { get; set; }
    public int AgentId { get; set; }
    public EstateAgent Agnet { get; set; }
    public double Cost { get; set; }
}