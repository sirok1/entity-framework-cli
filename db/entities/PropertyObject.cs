using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_framework_cli.db.entities;

[Table("Property object")]
public class PropertyObject
{
    [Key]
    public int id { get; set; }
    public int districtId { get; set; }
    public District district { get; set; }
    public string address { get; set; }
    public int floor { get; set; }
    public int roomsAmount { get; set; }
    public int typeId { get; set; }
    public TypeDb type { get; set; }
    public int Status { get; set; }
    public double cost { get; set; }
    public string description { get; set; }
    public int materialId { get; set; }
    public BuildingMaterial material { get; set; }
    public double area { get; set; }
    public DateTime updated { get; set; }
    public ICollection<Estimates> estimates { get; set; }
}