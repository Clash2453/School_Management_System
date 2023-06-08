using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Interfaces;

public interface IGradingService
{
    public Task<Status> AddGrade(GradeDto request, int teacherId);
    public Task<Status> DeleteGrade(int gradeId);
    public Task<Status> UpdateGrade(int gradeId, GradeDto request);
    public Task<Grade?> GetGrade(int requestId);
    public Task<List<Grade>> GetGradesByStudentId(int studentId);
    public Task<List<Grade>> GetGradesByTeacherId(int teacherId);
}