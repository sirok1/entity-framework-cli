using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_framework_cli.Db.Entities;

[Table("Building material")]
public class BuildingMaterial
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public ICollection<PropertyObject> PropertyObjects { get; set; }
}
