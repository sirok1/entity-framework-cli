using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_framework_cli.db.entities;

[Table("Estimates")]
public class Estimates
{
    [Key]
    public int Id { get; set; }
    public int PropertyObjectId { get; set; }
    public PropertyObject PropertyObject { get; set; }
    public DateTime EstimateDate { get; set; }
    public int CreteriaId { get; set; }
    public AssessmentCriteria Criteria { get; set; }
    [Required]
    public int Estimate { get; set; }
}