using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace working_with_db.db.entities;

[Table("Building material")]
public class BuildingMaterial
{
    [Key]
    public int id { get; set; }
    [Required]
    public string name { get; set; }
}
