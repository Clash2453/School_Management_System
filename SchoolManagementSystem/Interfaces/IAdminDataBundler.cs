using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Interfaces;

public interface IAdminDataBundler
{
    public Task<List<UserResultDto>> FetchAllStudents();
    public Task<List<UserResultDto>> FetchAllTeachers();
    public Task<List<UserResultDto>> FetchAllAdmins();
}