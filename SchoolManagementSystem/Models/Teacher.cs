using System.ComponentModel.DataAnnotations.Schema;
    using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Models.IntermediateTables;

namespace SchoolManagementSystem.Models;
public class Teacher
{
    public int TeacherId { get; set; }
    public string Title { get; set; } = null!;
    public User User { get; set; } = null!;
    public List<TeacherSubject> Subjects { get; set; } = null!;
    public List<Event> Events { get; set; } = null!;
    public List<Institution> Institutions = null!;
}
