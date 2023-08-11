namespace SchoolManagementSystem.Models.IntermediateTables;

public class UserFile
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string ObjectName { get; set; } = null!;
    public DateTime UploadTimestamp { get; set; }
    public User User { get; set; } = null!;
}