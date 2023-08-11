using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Models.IntermediateTables;

namespace SchoolManagementSystem.Models;

public class Subject
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Credits { get; set; }
    public virtual List<TeacherSubject> Teachers { get; set; } = null!;
    public List<SubjectMajor> SubjectSpecialties { get; set; } = null!; 
}   