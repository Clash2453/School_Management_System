using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Services.DataManipulation;

public class GradingService : IGradingService
{
    private readonly SchoolDbContext _context;
    public GradingService(SchoolDbContext context)
    {
        _context = context;
    }
    public async Task<Status> AddGrade(GradeDto request, int teacherId)
    {
        var student = await _context.Students.FindAsync(request.StudentId);
        var teacher = await _context.Teachers.FindAsync(teacherId);
        var subject = await _context.Subjects.FirstOrDefaultAsync(subject => subject.Name == request.Subject);
        
        if (student == null || teacher == null || subject == null)
            return Status.Fail;
        
        var grade = new Grade()
        {
            Value = request.Value,
            Grader = teacher,
            Owner = student,
            Date = DateTime.Now,
            Subject = subject,
            StudentYear = student.Course
        };      
        if (request.GradeType == "regular")
            grade.TypeOfGrade = GradeType.Regular;

        _context.Grades.Add(grade);
        await _context.SaveChangesAsync();
        return Status.Success;
    }

    public async Task<Status> DeleteGrade(int gradeId)
    {
        var grade = await _context.Grades.FindAsync(gradeId);
        if (grade == null)
            return Status.Fail;
        _context.Grades.Remove(grade);
        await _context.SaveChangesAsync();
        return Status.Success;
    }

    public async Task<Status> UpdateGrade(int gradeId, GradeDto request)
    {
        var grade = await _context.Grades.FindAsync(gradeId);
        if (grade == null)
            return Status.Fail;
        
        return Status.Success;
    }

    public async Task<Grade?> GetGrade(int requestedId)
    {
        return await _context.Grades.FindAsync(requestedId);
    }

    public async Task<List<Grade>> GetGradesByStudentId(int studentId)
    {
        var result = await _context.Grades
            .Include(g => g.Subject)
            .Include(g=> g.Grader)
            .ThenInclude(grader => grader.User)
            .Where(g => g.Owner.StudentId == studentId).ToListAsync();

        return result;
    }

    public async Task<List<Grade>> GetGradesByTeacherId(int teacherId)
    {
        return await _context.Grades.Where(g => g.Grader.TeacherId == teacherId).ToListAsync();

    }
}