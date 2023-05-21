using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Services;

public class UserManagementService : IUserManagementService
{
    private SchoolDbContext _context;
    private static IAuthenticationManager _authManager;

    public UserManagementService(SchoolDbContext context, IAuthenticationManager authManager)
    {
        _context = context;
        _authManager = authManager;
    }

    public async Task<User?> UserExists(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
    }

    public async Task<User?> AttemptLogin(LoginUserDto request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u=> u.Email == request.Email);
        if (user == null)
            return user;
        if (!_authManager.VerifyPasswordHash(request.Password, user.Password))
            return null;
        
        var encryptedToken = _authManager.CreateAuthenticationToken(request, user.Role);

        return user;
    }
    public async Task<Status> CreateUser(UserDto request)
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
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Status.Success;
    }
    public async Task<Status> CreateStudent(StudentDto request)
    {
        var user = await UserExists(request.UserId);
        if (user == null)
            return Status.Fail;

        user.Role = "Student";
        
        await _context.SaveChangesAsync();
        Student student = new Student()
        {
            StudentId = user.UserId,
            Group = request.Group,
            Course = request.Course,
            Specialty = request.Specialty,
            Faculty = request.Faculty,
        };
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return Status.Success;
    }
    public async Task<Status> CreateTeacher(TeacherDto request)
    {
        var user = await UserExists(request.UserId);
        if (user == null)
            return Status.Fail;

        user.Role = "Teacher";
        
        Teacher teacher = new Teacher()
        {
            Title = request.Title,
            TeacherId = request.UserId
        };
        _context.Teachers.Add(teacher);
        await _context.SaveChangesAsync();

        return Status.Success;
    }
    public async Task<Status> CreateAdmin(AdminDto request)
    {
        var user = await UserExists(request.UserId);
        if (user == null)
            return Status.Fail;

        user.Role = "Admin";
        
        Admin admin = new Admin()
        {
            AdminId = request.UserId
            
        };
        _context.Admins.Add(admin);
        await _context.SaveChangesAsync();

        return Status.Success;
    }

    public async Task<Status> DeleteUser(int id)
    {
        var user = await UserExists(id);
        if (user == null)
            return Status.Fail;

        string role = user.Role;
        _context.Users.Remove(user);
        
        return Status.Success;
    }
}