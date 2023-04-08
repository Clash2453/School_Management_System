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
        _authManager.CreatePasswordHash(request.Password, out string passwordHash, out string passwordSalt);
        var user = new User
        {
            Email = request.Email,
            Password = passwordHash,
            Salt = passwordSalt,
            Name = request.Name,
            Role = "Guest"
        };
        return user;
    }
}