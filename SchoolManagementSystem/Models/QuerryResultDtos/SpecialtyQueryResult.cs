namespace SchoolManagementSystem.Models.QuerryResultDtos;

public class SpecialtyQueryResult
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<string> Subjects { get; set; } = null!;
}