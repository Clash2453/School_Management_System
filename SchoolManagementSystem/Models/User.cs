using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models;

[Table( "Users" )]
public class User
{
    public User(){}

    public User(User user)
    {
        this.Name = user.Name;
        this.Email = user.Email;
        this.Password = user.Password;
        this.Salt = user.Salt;
        this.UserId = user.UserId;
    }
    [Key]
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Salt { get; set; } = null!;
}