using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Interfaces;

public interface IDataBundlingService
{
    public Task<StudentDataDto?> OrganizeStudentData(int id);
    public Task<TeacherDataDto> OrganizeTeacherData(int id);
    public Task<AdminResultDto?> OrganizeAdminData(int id);
    public Task<GradeDataDto?> OrganizeStudentGradeData(int id);
    public Task<TeacherDataDto> OrganizeTeacherGradeData(int id);
    public Task<Dictionary<string, List<GradeResultDto>>?> OrganizeGradesPerSubjects(int id);
}