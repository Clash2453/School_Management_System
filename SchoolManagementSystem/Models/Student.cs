using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Models.IntermediateTables;

namespace SchoolManagementSystem.Models;
public class Student
{
    public int StudentId { get; set; }
    public string Subject { get; set; } = null!;
    public string Specialty { get; set; } = null!;
    public string Faculty { get; set; } = null!;
    public int Group { get; set; }
    public int Course { get; set; }
    public virtual User User { get; set; } = null!;
    public List<StudentSubject> Subjects { get; set; } = null!;
    public List<StudentEvent> Events { get; set; } = null!;

}