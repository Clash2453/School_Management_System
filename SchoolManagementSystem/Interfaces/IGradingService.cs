using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Interfaces;

public interface IGradingService
{
    public Task<Status> AddGrade(GradeDto request);

    public Task<Status> DeleteGrade(int gradeId);

    public Task<Status> UpdateGrade(int gradeId);
    public Task<Status> GetGRades(int studentId);
}