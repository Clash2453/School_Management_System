namespace SchoolManagementSystem.Models.QuerryResultDtos;

public class StudentDataDto
{
    
    public int StudentId { get; set; }
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Faculty { get; set; } = null!;
    public int Course { get; set; }
    public string Specialty { get; set; } = null!;
    public int Group { get; set; }
    public float AvgGrade { get; set; }
    public string HighestAvgSubject { get; set; } = string.Empty;
    public float HighestAvg { get; set; }
    public string LowestAvgSubject { get; set; } = string.Empty;
    public float LowestAvg { get; set; }
    public float TotalAbsence { get; set; }
    public float ExcusedAbsence { get; set; }
    public float UnExcusedAbsence { get; set; }
}