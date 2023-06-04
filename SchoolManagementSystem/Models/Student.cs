using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Models.IntermediateTables;

namespace SchoolManagementSystem.Models;
public class Student
{
    public int StudentId { get; set; }
    public Specialty Specialty { get; set; } = null!;
    [ForeignKey("Specialty")]
    public int SpecialtyId { get; set; }
    [ForeignKey("Faculty")]
    public int FacultyId { get; set; }
    public Faculty Faculty { get; set; } = null!;
    public int Group { get; set; }
    public int Course { get; set; }
    public virtual User User { get; set; } = null!;
    public virtual List<Event> Events { get; set; } = null!;
}