using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entity_framework_cli.db.entities;

[Table("Type")]
public class TypeDb
{
    [Key]
    public int id { get; set; }
    [Required]
    public string name { get; set; }
    public ICollection<PropertyObject> propertyObjects { get; set; }
}