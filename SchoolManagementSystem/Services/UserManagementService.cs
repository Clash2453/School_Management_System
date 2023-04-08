using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Services;

public class UserManagementService
{
    public Student CreateStudent(StudentDto request, User user)
    {
        return new Student(request, user);
    }
    public Teacher CreateTeacher(TeacherDto request, User user)
    {
        return new Teacher(request, user);
    }
    public Admin CreateAdmin(AdminDto request, User user)
    {
        return new Admin(request, user);
    }
}