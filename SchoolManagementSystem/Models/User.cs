using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models;

[Table( "Users" )]
public class User
{
    [Key]
    public int UserId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Salt { get; set; } = null!;

    public string GetFullName() => $"{FirstName} {LastName}";
}