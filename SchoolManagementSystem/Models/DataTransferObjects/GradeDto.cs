namespace SchoolManagementSystem.Models.DataTransferObjects;

public class GradeDto
{
    public float Value { get; set; }
    public DateTime Date = DateTime.Now;
    public int StudentId { get; set; }
    public int TeacherId { get; set; }
}