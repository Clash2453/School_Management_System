using SchoolManagementSystem.Enums;

namespace SchoolManagementSystem.Models.DataTransferObjects;

public class GradeDto
{
    public float Value { get; set; }
    public DateTime Date = DateTime.Now;    
    public int StudentId { get; set; }
    public string Subject { get; set; } = null!;
    public string GradeType { get; set; } = null!;
}