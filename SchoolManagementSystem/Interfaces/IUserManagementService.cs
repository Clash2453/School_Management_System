using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Interfaces;

public interface IUserManagementService
{
    public Task<User?> UserExists(int id);
    public Task<Status> CreateStudent(StudentDto request);
    public Task<Status> CreateTeacher(TeacherDto request);
    public Task<Status> CreateAdmin(AdminDto request);
    public Task<Status> DeleteUser(int id);
    public Task<Status> CreateUser(UserDto request);
    public Task<User?> AttemptLogin(LoginUserDto request);
}