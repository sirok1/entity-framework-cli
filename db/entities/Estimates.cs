using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace working_with_db.db.entities;

[Table("Estimates")]
public class Estimates
{
    [Key]
    public int id { get; set; }
    [Required]
    public PropertyObject propertyObject { get; set; }
    public DateTime estimateDate { get; set; }
    [Required]
    public AssessmentCriteria criteria { get; set; }
    [Required]
    public int estimate { get; set; }
}