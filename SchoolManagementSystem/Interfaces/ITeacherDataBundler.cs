using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Interfaces;

public interface ITeacherDataBundler
{
    public Task<TeacherDataDto> OrganizeTeacherData(int id);
    public Task<TeacherDataDto> OrganizeTeacherGradeData(int id);
}