using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace working_with_db.db.entities;

[Table("Estate agent")]
public class EstateAgent
{
    [Key]
    public int id { get; set; }
    [Required]
    public string surname { get; set; }
    [Required]
    public string name { get; set; }
    [Required]
    public string fatherName { get; set; }
    public string phone { get; set; }
    public ICollection<Selling> sellings { get; set; }
}