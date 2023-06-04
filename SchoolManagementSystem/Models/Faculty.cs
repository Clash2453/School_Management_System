namespace SchoolManagementSystem.Models;

public class Faculty
{
    public int FacultyId { get; set; }
    public string Name { get; set; } = null!;
    public List<Specialty> Specialties = new List<Specialty>();
}