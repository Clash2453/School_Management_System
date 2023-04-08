using System.ComponentModel.DataAnnotations.Schema;
using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Models.IntermediateTables;

namespace SchoolManagementSystem.Models;
[Table( "Students" )]
public class Student : User
{
    public Student()
    {
        
    }

    public Student(StudentDto dto, User user):base(user)
    {
        this.Course = dto.Course;
        this.Specialty = dto.Specialty;
        this.Faculty = dto.Faculty;
        this.Group = dto.Group;
    }
    public string Subject { get; set; } = null!;
    public string Specialty { get; set; } = null!;
    public string Faculty { get; set; } = null!;
    public int Group { get; set; }
    public int Course { get; set; }
    public List<StudentSubject> Subjects { get; set; } = null!;
    public List<StudentEvent> Events { get; set; } = null!; 
    
}