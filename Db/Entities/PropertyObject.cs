using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_framework_cli.Db.Entities;

[Table("Property object")]
public class PropertyObject
{
    [Key]
    public int Id { get; set; }
    public int DistrictId { get; set; }
    public District District { get; set; }
    public string Address { get; set; }
    public int Floor { get; set; }
    public int RoomsAmount { get; set; }
    public int TypeId { get; set; }
    public TypeDb Type { get; set; }
    public int Status { get; set; }
    public double Cost { get; set; }
    public string Description { get; set; }
    public int MaterialId { get; set; }
    public BuildingMaterial Material { get; set; }
    public double Area { get; set; }
    public DateTime Updated { get; set; }
    public ICollection<Estimates> Estimates { get; set; }
}