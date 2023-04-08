using System.ComponentModel.DataAnnotations.Schema;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Models;
[Table( "Admins" )]
public class Admin : User
{
    public Admin(AdminDto request, User user):base(user)
    {
        
    }
}