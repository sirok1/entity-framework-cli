using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace working_with_db.db.entities;

[Table("Assessment criteria")]
public class AssessmentCriteria
{
    [Key]
    public int id { get; set; }
    [Required]
    public string name { get; set; }
    public ICollection<Estimates> estimates { get; set; }
}