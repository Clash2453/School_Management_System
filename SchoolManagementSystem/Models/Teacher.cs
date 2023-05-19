using System.ComponentModel.DataAnnotations.Schema;
    using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Models.IntermediateTables;

namespace SchoolManagementSystem.Models;
[Table( "Teacher" )]
public class Teacher
{
    public int TeacherId { get; set; }
    public string Title { get; set; } = null!;
    public virtual User User { get; set; } = null!;
    public virtual List<TeacherSubject> Subjects { get; set; } = null!;
    public virtual List<Event> Events { get; set; } = null!;
}
