using System.ComponentModel.DataAnnotations.Schema;
using SchoolManagementSystem.Models.IntermediateTables;

namespace SchoolManagementSystem.Models;
[Table( "Teacher" )]
public class Teacher : User
{
    public string Title { get; set; } = null!;
    public List<TeacherSubject> Subjects { get; set; } = null!;
    public List<TeacherEvent> Events { get; set; } = null!;
}