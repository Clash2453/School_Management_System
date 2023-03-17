using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models;
[Table( "Students" )]
public class Student : User
{
    public string Subject { get; set; } = null!;
    public string Specialty { get; set; } = null!;
    public string Faculty { get; set; } = null!;
    public int Group { get; set; }
    public int Course { get; set; }
    public List<StudentSubject> Subjects { get; set; } = null!;
    public List<StudentEvent> Events { get; set; } = null!;
    
}