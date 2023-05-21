namespace SchoolManagementSystem.Models.DataTransferObjects;

public class SubjectDto
{
    public string Name { get; set; } = null!;
    public List<int> StudentIds { get; set; } = null!;
    public List<int> TeacherIds { get; set; } = null!;
}