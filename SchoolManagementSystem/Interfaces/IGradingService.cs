using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Interfaces;

public interface IGradingService
{
    public Task<Status> AddGrade(GradeDto request);

    public Task<Status> DeleteGrade(int gradeId);

    public Task<Status> UpdateGrade(int gradeId, GradeDto request);
    public Task<List<Grade>> GetGrades(int requestId);
}