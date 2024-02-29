using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace working_with_db.db.entities;

[Table("Districts")]
public class District
{
    [Key]
    public int id { get; set; }
    [Required]
    public string name { get; set; }
    
}