using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models;

[Table( "Users" )]
public class User
{
    [Key]
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
    public byte[] Password { get; set; } = null!;
    public byte[] Salt { get; set; } = null!;
}