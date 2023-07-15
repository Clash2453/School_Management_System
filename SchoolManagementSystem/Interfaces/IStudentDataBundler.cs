using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.QuerryResultDtos;
using SchoolManagementSystem.Services.DataOrganization;

namespace SchoolManagementSystem.Interfaces;

public interface IStudentDataBundler
{
    public Task<StudentDataDto?> OrganizeStudentData(int id);
    public Task<GradeDataDto?> OrganizeStudentGradeData(int id);
    public float CalculateAverageGrade(IEnumerable<GradeValue> grades);
     
    public List<GradeValue> GetGradeValues(List<Grade> grades);
     
    public Task<List<Grade>> GetStudentGrades(int studentId);
}