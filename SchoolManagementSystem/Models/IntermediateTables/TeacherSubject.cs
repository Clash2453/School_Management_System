using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models.IntermediateTables;
[Table("TeacherSubjects")]
public class TeacherSubject
{
    [Key]
    public int Id { get; set; }
}