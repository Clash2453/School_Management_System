namespace SchoolManagementSystem.Models.QuerryResultDtos;

public class UserResultDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
    public Dictionary<string, string> Attributes { get; set; } = null!;
}