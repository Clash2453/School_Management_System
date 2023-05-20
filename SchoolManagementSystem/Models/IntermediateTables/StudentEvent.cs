using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models.IntermediateTables;
[Table("StudentEvents")]
public class StudentEvent
{
    [Key]
    public int Id { get; set; }
    public Student Student { get; set; } = null!;
    public Event Event { get; set; } = null!;
}