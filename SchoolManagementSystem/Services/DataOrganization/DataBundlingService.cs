using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Services.DataOrganization;

public class DataBundlingService : IDataBundlingService
{
    private readonly IGradingService _gradingService;
    private readonly IAbsenceService _absenceService;
    private readonly ISubjectService _subjectService;
    private readonly IUserManagementService _userService;
    
    public DataBundlingService(IGradingService gradingService,
        IAbsenceService absenceService,
        ISubjectService subjectService,
        IUserManagementService userService)
    {
        _gradingService = gradingService;
        _absenceService = absenceService;
        _subjectService = subjectService;
        _userService = userService;
    }

    public async Task<StudentDataDto?> OrganizeStudentData(int id)
    {
        var userData = await _userService.FetchUser(id);
        var studentData = await _userService.FetchStudent(id);
        var subjectData = await _subjectService.GetSubjectsByStudent(id);
        if (userData == null || studentData == null)
            return null;
        
        var grades = await _gradingService.GetGrades(userData.UserId);

        var gradeValues = grades.Select(g => new { Subject = g.Subject.Name, Value = g.Value }).ToList();
        var average = gradeValues.Select(g => g.Value).Average();

        var groupedGrades = gradeValues
            .GroupBy(grade => grade.Subject)
            .Select(group =>
            {
                var averageGrade = group.Average(g => g.Value);
                return new
                {
                    Subject = group.Key,
                    AverageGrade = averageGrade
                };

            })
            .OrderBy(g => g.AverageGrade).ToList();

        var min = groupedGrades.First();
        var max = groupedGrades.Last();
        // var absences = await _absenceService.GetAbsenceByStudent(userData.UserId);
        
        var response = new StudentDataDto
        {
            StudentId = studentData.StudentId,
            Name = userData.Name,
            Faculty = studentData.Faculty,
            Course = studentData.Course,
            Specialty = studentData.Specialty,
            Group = studentData.Group,
            AvgGrade = average,
            HighestAvgSubject = max.Subject,
            HighestAvg = max.AverageGrade,
            LowestAvgSubject = min.Subject,
            LowestAvg = min.AverageGrade
        };
        return response;
        
    }
}