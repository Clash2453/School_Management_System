using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Services.DataOrganization;

public class AdminDataBundler: IAdminDataBundler
{
    private readonly IUserManagementService _userManagementService;
    public AdminDataBundler(IUserManagementService userManagementService)
    {
        _userManagementService = userManagementService;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<List<UserResultDto>> FetchAllStudents()
    {
        var students = await _userManagementService.FetchAllStudents();
        var result = students.Select(student => new UserResultDto()
        {
            Id = student.StudentId,
            Name = student.User.GetFullName(),
            Role = student.User.Role,
            Email = student.User.Email,
            Attributes = new Dictionary<string, string>
            {
                { "Faculty", student.Faculty.Name },
                { "Major", student.Major.Name },
                { "Course", student.Course.ToString() }
            },
        }).ToList();
        return result;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<List<UserResultDto>> FetchAllTeachers()
    {
        var teachers = await _userManagementService.FetchAllTeachers();
        var result  = teachers.Select(teacher => new UserResultDto()
        {
            Id = teacher.TeacherId,
            Name = teacher.User.GetFullName(),
            Role = teacher.User.Role,
            Attributes = new Dictionary<string, string>
            {
                { "Title", teacher.Title }
            },
            Email = teacher.User.Email
        }).ToList();
        return result;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<List<UserResultDto>> FetchAllAdmins()
    {
        var admins = await _userManagementService.FetchAllAdmins();
        var result = admins.Select(admin => new UserResultDto
            {
                Id = admin.AdminId,
                Name = admin.User.GetFullName(),
                Email = admin.User.Email,
                Role = admin.User.Role,
            }).ToList();
        return result;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<AdminResultDto?> OrganizeAdminData(int id)
    {
        var userData = await _userManagementService.FetchUser(id);
        var studentData = await _userManagementService.FetchAdmin(id);
        if (userData == null || studentData == null)
            return null;
        return new AdminResultDto()
        {
            Name = userData.GetFullName(),
            Id = userData.UserId
        };
    }
}