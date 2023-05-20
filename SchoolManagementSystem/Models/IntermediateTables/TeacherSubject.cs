using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models.IntermediateTables;
[Table("TeacherSubjects")]
public class TeacherSubject
{
    [Key]
    public int Id { get; set; }
    public Teacher Teacher { get; set; } = null!;
    public Subject Subject { get; set; } = null!;
}