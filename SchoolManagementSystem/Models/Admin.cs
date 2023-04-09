using System.ComponentModel.DataAnnotations.Schema;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Models;
[Table( "Admins" )]
public class Admin
{
    public int AdminId { get; set; }
    public virtual User User { get; set; } = null!;
}