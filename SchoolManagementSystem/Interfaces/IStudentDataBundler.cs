using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Interfaces;

public interface IStudentDataBundler
{
    public Task<StudentDataDto?> OrganizeStudentData(int id);
    public Task<GradeDataDto?> OrganizeStudentGradeData(int id);
}