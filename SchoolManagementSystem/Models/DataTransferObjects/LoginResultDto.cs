namespace SchoolManagementSystem.Models.DataTransferObjects;

public class LoginResultDto
{
    public int UserId { get; set; }
    public string UserRole { get; set; } = string.Empty;
}