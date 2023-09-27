using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Models.QuerryResultDtos;
using AdminDto = SchoolManagementSystem.Models.DataTransferObjects.AdminDto;

namespace SchoolManagementSystem.Services.DataManipulation;

public class UserManagementService : IUserManagementService
{
    private readonly SchoolDbContext _context;
    private readonly IAuthenticationManager _authManager;

    public UserManagementService(SchoolDbContext context, IAuthenticationManager authManager)
    {
        _context = context;
        _authManager = authManager;
    }
    /// <summary>
    /// Returns a single user via id
    /// </summary>
    public async Task<User?> FetchUser(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
    }
    /// <summary>
    /// Returns a single student via id
    /// </summary>
    public async Task<Student?> FetchStudent(int id)
    {
        return await _context.Students.Include(student => student.Major).Include(student => student.Faculty).FirstOrDefaultAsync(s => s.StudentId == id);
    }
    /// <summary>
    /// Returns a single teacher via id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Teacher?> FetchTeacher(int id)
    {
        return await _context.Teachers.FirstOrDefaultAsync(s => s.TeacherId == id);
    }
    /// <summary>
    /// Returns an administrator via id
    /// </summary>
    public async Task<Admin?> FetchAdmin(int id)
    {
        return await _context.Admins.FirstOrDefaultAsync(s => s.AdminId == id);
    }

    #region ToBeChanged
    /// <summary>
    /// Returns a list of all admins
    /// </summary>
    public async Task<List<Admin>> FetchAllAdmins()
    {
        return await _context.Admins.Include(admin => admin.User).ToListAsync();
    }
    /// <summary>
    /// Returns a list of all students
    /// </summary>
    /// <returns></returns>
    public async Task<List<Student>> FetchAllStudents()
    {
        var result = await _context.Students
            .Include(student => student.User)
            .Include(student => student.Faculty )
            .Include(student => student.Major)
            .ToListAsync();
        return result; 
    }
    /// <summary>
    /// Returns a list of all teachers
    /// </summary>
    /// <returns></returns>
    public async Task<List<Teacher>> FetchAllTeachers()
    {
        return await _context.Teachers.Include(teacher=> teacher.User).ToListAsync();
    }
    #endregion
    /// <summary>
    /// Returns a list of all guests
    /// </summary>
    /// <returns></returns>
    public async Task<List<UserResultDto>> FetchGuests()
    {
        return await _context.Users.Where(u => u.Role == "guest").Select(u => new UserResultDto()
        {
            Id = u.UserId,
            Name = $"",
            Email = u.Email,
        }).ToListAsync();
    }
    /// <summary>
    /// Attempts to log in a user into the system
    /// </summary>
    /// <param name="request">The user's login data</param>
    /// <returns>A user object if the login operation was successful</returns>
    public async Task<User?> AttemptLogin(LoginUserDto request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u=> u.Email == request.Email);
        if (user == null)
            return user;
        if (!_authManager.VerifyPasswordHash(request.Password, user.Password))
            return null;
        
        var encryptedToken = _authManager.CreateAuthenticationToken(request, user.Role, user.UserId);

        return user;
    }
    /// <summary>
    /// Returns a list of teachers
    /// </summary>
    public async Task<List<UserResultDto>> FetchTeachers()
    {
        return await _context.Teachers.Include(t => t.User ).Select( t => new UserResultDto()
        {
            Name = t.User.GetFullName(),
            Email = t.User.Email,
            Id = t.TeacherId
        }).ToListAsync();
    }
    /// <summary>
    /// Returns a list of students that study the same subject
    /// </summary>
    public async Task<List<Student>> FetchStudentsBySubject(int subjectId)
    {
        var specialties = await  _context.SubjectMajors.Where(specialty => specialty.Subject.Id == subjectId).Select(subSpecialty => subSpecialty.Major).ToListAsync();
        return await _context.Students
            .Include(student=> student.User)
            .Where(student => specialties.Contains(student.Major)).ToListAsync();
    }
    /// <summary>
    /// Creates a new user entry into the system
    /// </summary>
    /// <returns>Status success or status fail if the operation fails</returns>
    public async Task<Status> CreateUser(UserDto request)
    {
        _authManager.CreatePasswordHash(request.Password, out string passwordHash, out string passwordSalt);
        var user = new User
        {
            Email = request.Email,
            Password = passwordHash,
            Salt = passwordSalt,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Role = "Guest"
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Status.Success;
    }
    /// <summary>
    /// Creates a new student entry into the system
    /// </summary>
    /// <returns>Status success or status fail if the operation fails</returns>
    public async Task<Status> CreateStudent(StudentDto request)
    {
        var user = await FetchUser(request.UserId);
        if (user == null)
            return Status.Fail;

        user.Role = "Student";
        
        await _context.SaveChangesAsync();
        Student student = new Student()
        {
            StudentId = user.UserId,
            Group = request.Group,
            Course = request.Course,
            MajorId = request.Specialty,
            FacultyId = request.Faculty,
        };
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return Status.Success;
    }
    /// <summary>
    /// Creates a new teacher entry into the system
    /// </summary>
    /// <returns>Status success or status fail if the operation fails</returns>
    public async Task<Status> CreateTeacher(TeacherDto request)
    {
        var user = await FetchUser(request.UserId);
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
    /// <summary>
    /// Creates a new admin entry into the system
    /// </summary>
    /// <returns>Status success or status fail if the operation fails</returns>

    public async Task<Status> CreateAdmin(AdminDto request)
    {
        var user = await FetchUser(request.UserId);
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
    /// <summary>
    /// Deletes a user entry from the system via id
    /// </summary>
    /// <returns>Status success or status fail if the operation fails</returns>

    public async Task<Status> DeleteUser(int id)
    {
        var user = await FetchUser(id);
        if (user == null)
            return Status.Fail;
        
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return Status.Success;
    }
}