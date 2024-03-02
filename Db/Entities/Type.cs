using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entity_framework_cli.Db.Entities;

[Table("Type")]
public class TypeDb
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public ICollection<PropertyObject> PropertyObjects { get; set; }
}