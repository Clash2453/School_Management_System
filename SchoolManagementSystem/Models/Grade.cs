namespace SchoolManagementSystem.Models;

public class Grade
{
    public float Value { get; set; }
    public int GradeId { get; set; }
    public DateTime Date { get; set; }
    public virtual Student Owner { get; set; } = null!;
    public virtual Teacher Grader { get; set; } = null!;
}