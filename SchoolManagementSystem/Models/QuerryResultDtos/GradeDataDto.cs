namespace SchoolManagementSystem.Models.QuerryResultDtos;

public class GradeDataDto
{
    public List<List<GradeResultDto>> Grades { get; set; } = new();
    public List<List<GradeResultDto>> TermGrades { get; set; } = new();
    public List<List<GradeResultDto>> YearlyGrades { get; set; } = new();

}