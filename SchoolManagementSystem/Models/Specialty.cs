using SchoolManagementSystem.Models.IntermediateTables;

namespace SchoolManagementSystem.Models;

public class Specialty
{
    public int SpecialtyId { get; set; }
    public string Name { get; set; } = null!;
    public Faculty Faculty { get; set; } = null!;
    public List<SubjectSpecialty> SubjectSpecialties { get; set; } = null!;
}