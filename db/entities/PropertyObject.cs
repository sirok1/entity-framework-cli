using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace working_with_db.db.entities;

[Table("Property object")]
public class PropertyObject
{
    [Key]
    public int id { get; set; }
    [Required]
    public District district { get; set; }
    public string address { get; set; }
    public int floor { get; set; }
    public int roomsAmount { get; set; }
    [Required]
    public TypeDb type { get; set; }
    public int Status { get; set; }
    public double cost { get; set; }
    public string description { get; set; }
    [Required]
    public BuildingMaterial Material { get; set; }
    public double area { get; set; }
    public DateTime updated { get; set; }
}