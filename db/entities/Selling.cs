using System.ComponentModel.DataAnnotations;

namespace Entity_framework_cli.db.entities;

public class Selling
{
    [Key]
    public int id { get; set; }
    [Required]
    public PropertyObject propertyObject { get; set; }
    public DateTime sellDate { get; set; }
    public int agentId { get; set; }
    public EstateAgent agnet { get; set; }
    public double cost { get; set; }
}