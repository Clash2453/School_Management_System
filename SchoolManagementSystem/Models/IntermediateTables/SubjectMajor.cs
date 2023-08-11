using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models.IntermediateTables;

public class SubjectMajor
{
    public int Id { get; set; }
    public Major Major { get; set; } = null!;
    public Subject Subject { get; set; } = null!;
}