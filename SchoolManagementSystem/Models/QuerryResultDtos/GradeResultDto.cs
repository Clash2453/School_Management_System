namespace SchoolManagementSystem.Models.QuerryResultDtos;

public class GradeResultDto
{
    public float Value { get; set; }
    private DateTime _date {get; set; }
    public DateTime Date
    {
        get => _date;
        set => _date = new DateTime(value.Year, value.Month, value.Day);
    }

    public virtual string Subject { get; set; } = string.Empty;
}