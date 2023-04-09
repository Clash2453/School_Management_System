namespace SchoolManagementSystem.Models.DataTransferObjects;

public class StudentDto
{
    public int UserId { get; set; } 
    public string Specialty { get; set; } = null!;
    public string Faculty { get; set; } = null!;
    public int Group { get; set; }
    public int Course { get; set; }
}