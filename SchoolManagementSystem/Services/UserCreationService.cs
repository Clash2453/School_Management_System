using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Services;

public class UserCreationService
{
    private static AuthenticationManager _authManager;
    public UserCreationService(AuthenticationManager authManager)
    {
        _authManager = authManager;
    }
    public User CreateUser(UserDto request)
    {
        _authManager.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);
        var user = new User();
        user.Email = request.Email;
        user.Password = passwordHash;
        user.Salt = passwordSalt;
        user.Name = request.Name;
        user.Role = "Guest";
        return user;
    }
    // public Student CreateSTudent()
    // {
    //     
    // }
    // public Teacher CreateTeacher()
    // {
    //     
    // }
    // public Admin CreateAdmin()
    // {
    //     
    // }
}