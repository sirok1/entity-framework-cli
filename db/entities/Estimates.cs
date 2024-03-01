using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace working_with_db.db.entities;

[Table("Estimates")]
public class Estimates
{
    [Key]
    public int id { get; set; }
    public int propertyObjectId { get; set; }
    public PropertyObject propertyObject { get; set; }
    public DateTime estimateDate { get; set; }
    public int creteriaId { get; set; }
    public AssessmentCriteria criteria { get; set; }
    [Required]
    public int estimate { get; set; }
}