namespace SchoolManagementSystem.Models.QuerryResultDtos;

public class FacultyQueryResult
{
    public string Name { get; set; }
    public List<SpecialtyQueryResult> Specialties { get; set; }
}