using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models.IntermediateTables;

[Table("TeacherEvents")]
public class TeacherEvent
{
    [Key]
    public int Id { get; set; }
    public Teacher Teacher { get; set; } = null!;
    public Event Event { get; set; } = null!;
}