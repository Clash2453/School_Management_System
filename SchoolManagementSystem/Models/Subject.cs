using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models;

public class Subject
{
    [Key]
    public int SubjectId { get; set; }
    public string Name { get; set; } = null!;
    public string Course { get; set; } = null!;
}