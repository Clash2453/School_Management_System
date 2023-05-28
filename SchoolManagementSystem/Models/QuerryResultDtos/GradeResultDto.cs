namespace SchoolManagementSystem.Models.QuerryResultDtos;

public class GradeResultDto
{
    public float Value { get; set; }
    public DateTime Date { get; set; }
    public virtual string Grader { get; set; } = string.Empty;
    public virtual string Subject { get; set; } = string.Empty;
}