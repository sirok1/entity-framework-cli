using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_framework_cli.Db.Entities;

[Table("Estate agent")]
public class EstateAgent
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string FatherName { get; set; }
    public string Phone { get; set; }
    public ICollection<Selling> Sellings { get; set; }
}