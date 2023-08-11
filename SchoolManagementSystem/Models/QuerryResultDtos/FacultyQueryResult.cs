namespace SchoolManagementSystem.Models.QuerryResultDtos;

public class FacultyQueryResult
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Major> Specialties { get; set; } = null!;
}