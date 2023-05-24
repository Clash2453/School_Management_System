using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Interfaces;

public interface IDataBundlingService
{
    public Task<StudentDataDto?> OrganizeStudentData(int id);
}