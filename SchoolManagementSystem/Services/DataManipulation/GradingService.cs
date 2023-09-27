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
    /// <summary>
    /// Adds a grade entry in to the database
    /// </summary>
    /// <param name="request">Entry data</param>
    /// <param name="teacherId">Id of the teacher adding the grade</param>
    /// <returns>Status of the operation</returns>
    public async Task<Status> AddGrade(GradeDto request, int teacherId)
    {
        var student = await _context.Students.FindAsync(request.StudentId);
        var teacher = await _context.Teachers.FindAsync(teacherId);
        var subject = await _context.Subjects.FirstOrDefaultAsync(subject => subject.Name == request.Subject);
        
        if (student == null || teacher == null || subject == null)
            return Status.Fail;
        
        var grade = new Grade
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
    /// <summary>
    /// Deletes a grade entry from the database
    /// </summary>
    /// <param name="gradeId">Id of the grade</param>
    /// <returns>Status of the operation</returns>
    public async Task<Status> DeleteGrade(int gradeId)
    {
        var grade = await _context.Grades.FindAsync(gradeId);
        if (grade == null)
            return Status.Fail;
        _context.Grades.Remove(grade);
        await _context.SaveChangesAsync();
        return Status.Success;
    }
    /// <summary>
    /// Updates an existing grade entry
    /// </summary>
    /// <param name="gradeId">Id of the grade</param>
    /// <param name="request">The new information about the entry</param>
    /// <returns></returns>
    public async Task<Status> UpdateGrade(int gradeId, GradeDto request)
    {
        var grade = await _context.Grades.FindAsync(gradeId);
        if (grade == null)
            return Status.Fail;
        
        return Status.Success;
    }
    /// <summary>
    /// Gets a grade entry from the database by id
    /// </summary>
    /// <param name="requestedId">The id of the requested grade</param>
    /// <returns>Grade object or null</returns>
    public async Task<Grade?> GetGrade(int requestedId)
    {
        return await _context.Grades.FindAsync(requestedId);
    }
    /// <summary>
    /// Gets all grade of a student
    /// </summary>
    /// <param name="studentId">Id of the student</param>
    /// <returns>List of grades belonging to the student</returns>
    public async Task<List<Grade>> GetGradesByStudentId(int studentId)
    {
        var result = await _context.Grades
            .Include(g => g.Subject)
            .Include(g=> g.Grader)
            .ThenInclude(grader => grader.User)
            .Where(g => g.Owner.StudentId == studentId).ToListAsync();

        return result;
    }
    /// <summary>
    /// Gets all the grades a teacher has added in the system
    /// </summary>
    /// <param name="teacherId">Id of the teacher</param>
    /// <returns>List with all grades added by that teacher</returns>
    public async Task<List<Grade>> GetGradesByTeacherId(int teacherId)
    {
        return await _context.Grades.Where(g => g.Grader.TeacherId == teacherId).ToListAsync();

    }
}