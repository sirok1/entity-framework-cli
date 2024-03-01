using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_framework_cli.db.entities;

[Table("Districts")]
public class District
{
    [Key]
    public int id { get; set; }
    [Required]
    public string name { get; set; }
    public ICollection<PropertyObject> propertyObjects { get; set; }
    
}