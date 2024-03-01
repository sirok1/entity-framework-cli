using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_framework_cli.db.entities;

[Table("Assessment criteria")]
public class AssessmentCriteria
{
    [Key]
    public int id { get; set; }
    [Required]
    public string name { get; set; }
    public ICollection<Estimates> estimates { get; set; }
}