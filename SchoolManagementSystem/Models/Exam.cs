using SchoolManagementSystem.Enums;

namespace SchoolManagementSystem.Models;

public class Exam
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime Date { get; set; }
    // Other exam properties
    public TimeSpan Duration { get; set; } // Duration of the exam
    public string Location { get; set; } = null!;
    public string Instructions { get; set; } = null!;
    public decimal MaximumScore { get; set; }
    public ExamType Type { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; } = null!;

    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;

    public ICollection<Grade> Results { get; set; } = null!;
}
