namespace SchoolManagementSystem.Models.DataTransferObjects;

public class EmailDto
{
    public string Receiver { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public string Body { get; set; } = null!;
}