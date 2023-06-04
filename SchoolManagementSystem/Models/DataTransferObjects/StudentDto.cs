namespace SchoolManagementSystem.Models.DataTransferObjects;

public class StudentDto
{
    public int UserId { get; set; } 
    public int Specialty { get; set; }
    public int Faculty { get; set; }
    public int Group { get; set; }  
    public int Course { get; set; }
}