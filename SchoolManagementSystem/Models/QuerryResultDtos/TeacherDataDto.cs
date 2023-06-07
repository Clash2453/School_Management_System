namespace SchoolManagementSystem.Models.QuerryResultDtos;

public class TeacherDataDto
{
    public string Name { get; set; } = null!;
    public int Id { get; set; }
    public Dictionary<string, List<StudentDataDto>> Students { get; set; } = null!;
}