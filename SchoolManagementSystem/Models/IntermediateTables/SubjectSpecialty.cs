using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models.IntermediateTables;

public class SubjectSpecialty
{
    public int Id { get; set; }
    public Specialty Specialty { get; set; } = null!;
    public Subject Subject { get; set; } = null!;
}