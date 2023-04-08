using System.ComponentModel.DataAnnotations.Schema;
using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Models.IntermediateTables;

namespace SchoolManagementSystem.Models;
[Table( "Teacher" )]
public class Teacher : User
{
    public Teacher(TeacherDto teacherDto, User user):base(user)
    {
        this.Title = teacherDto.Title;
    }
    public string Title { get; set; } = null!;
    public List<TeacherSubject> Subjects { get; set; } = null!;
    public List<TeacherEvent> Events { get; set; } = null!;
}
