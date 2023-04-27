using SchoolManagementSystem.Data;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Services;

public class GradingService : IGradingService
{
    private readonly SchoolDbContext _context;
    public GradingService(SchoolDbContext context)
    {
        _context = context;
    }
    public async Task<Status> AddGrade(GradeDto request)
    {
        return Status.Success;
    }
    
    public async Task<Status> DeleteGrade(int gradeId)
    {
        return Status.Success;
    }

    public async Task<Status> UpdateGrade(int gradeId)
    {
        return Status.Success;
    }

    public async Task<Status> GetGRades(int studentId)
    {
        return Status.Success;
    }
}