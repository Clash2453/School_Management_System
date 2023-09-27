namespace SchoolManagementSystem.Models.DataTransferObjects;

public class MajorDto
{
    public string Name { get; set; } = null!;
    public int FacultyId { get; set; }
    public List<int> SubjectIds { get; set; } = null!;
}