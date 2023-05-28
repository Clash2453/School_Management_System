using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Interfaces;

public interface IDataBundlingService
{
    public Task<StudentDataDto?> OrganizeStudentData(int id);
    public Task<GradeDataDto?> OrganizeStudentGradeData(int id);
    public Task<GradeDataDto?> OrganizeTeacherGradeData(int id);
}