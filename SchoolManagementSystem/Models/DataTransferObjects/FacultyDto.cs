namespace SchoolManagementSystem.Models.DataTransferObjects;

public class FacultyDto
{
    public string Name { get; set; } = null!;
    public List<int> SpecialtyIds { get; set; } = null!;
}