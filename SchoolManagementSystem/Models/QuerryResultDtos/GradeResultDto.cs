using SchoolManagementSystem.Enums;

namespace SchoolManagementSystem.Models.QuerryResultDtos;

public sealed class GradeResultDto
{
    public float Value { get; set; }
    public int Term { get; set; }
    public int Course { get; set; }
    public DateTime Date { get; set; }
    public String Type { get; set; } = String.Empty;
    public string Subject { get; init; } = string.Empty;
}