namespace SchoolManagementSystem.Models.QuerryResultDtos;

public class StudentDataDto
{
    
    public int StudentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Faculty { get; set; } = string.Empty;
    public int Course { get; set; }
    public string Specialty { get; set; } = string.Empty;
    public int Group { get; set; }
    public float AvgGrade { get; set; }
    public string HighestAvgSubject { get; set; } = string.Empty;
    public int HighestAvg { get; set; }
    public string LowestAvgSubject { get; set; } = string.Empty;
    public int LowestAvg { get; set; }
    public int TotalAbsence { get; set; }
}