namespace SchoolManagementSystem.Models.DataTransferObjects;

public class SubjectDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<int> TeacherIds { get; set; } = null!;
    

}