namespace SchoolManagementSystem.Models.QuerryResultDtos;

public class FacultyQueryResult
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Specialty> Specialties { get; set; } = null!;
}