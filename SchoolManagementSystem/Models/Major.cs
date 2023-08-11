using SchoolManagementSystem.Models.IntermediateTables;

namespace SchoolManagementSystem.Models;

public class Major
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Faculty Faculty { get; set; } = null!;
    public List<SubjectMajor> SubjectSpecialties { get; set; } = null!;
}