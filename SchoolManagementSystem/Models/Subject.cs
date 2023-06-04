using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Models.IntermediateTables;

namespace SchoolManagementSystem.Models;

public class Subject
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual List<TeacherSubject> Teacher { get; set; } = null!;
}