using SchoolManagementSystem.Enums;

namespace SchoolManagementSystem.Models;

public class Grade
{
    public int GradeId { get; set; }
    public float Value { get; set; }
    public DateTime Date { get; set; }
    public GradeType  TypeOfGrade { get; set; }
    public int Term { get; set; }
    public int StudentYear { get; set; }
    public virtual Student Owner { get; set; } = null!;
    public virtual Teacher Grader { get; set; } = null!;
    public virtual Subject Subject { get; set; } = null!;
}