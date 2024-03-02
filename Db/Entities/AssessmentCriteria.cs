using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_framework_cli.Db.Entities;

[Table("Assessment criteria")]
public class AssessmentCriteria
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public ICollection<Estimates> Estimates { get; set; }
}