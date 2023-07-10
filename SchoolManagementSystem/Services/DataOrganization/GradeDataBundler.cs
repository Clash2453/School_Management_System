using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Services.DataOrganization;

public class GradeDataBundler : IGradeDataBundler
{

    private readonly IGradingService _gradingService;
    private readonly ISubjectService _subjectService;
    private readonly IUserManagementService _userService;
    
    public GradeDataBundler(IGradingService gradingService,
        ISubjectService subjectService,
        IUserManagementService userService)
    {
        _gradingService = gradingService;
        _subjectService = subjectService;
        _userService = userService;
    }
    public async Task<Dictionary<string, List<GradeResultDto>>?> OrganizeGradesPerSubjects(int id)
    {
        var user = await _userService.FetchStudent(id);
        
        if(user == null)
            return new Dictionary<string, List<GradeResultDto>>();
        
        var subjects = await _subjectService.GetSubjectsByStudent(user.Specialty.SpecialtyId);
        var grades = await _gradingService.GetGradesByStudentId(id);
        
        if (grades.Count == 0)
            return new Dictionary<string, List<GradeResultDto>>();
        
        var gradeValues = grades.Select(g => 
                new GradeResultDto()
                {
                    Subject = g.Subject.Name,
                    Value = g.Value,
                    Date = new DateTime(g.Date.Year, g.Date.Month, g.Date.Day)

                })
            .GroupBy(g=> g.Subject)
            .Select(g => g.ToList())
            .ToList();  
        Dictionary<string, List<GradeResultDto>> result = new();
        for (int i = 0; i < subjects.Count; i++)
        {
            var subject = subjects[i].Name;
            result.Add(subject, gradeValues.FirstOrDefault(value => value[0].Subject == subject) ?? new List<GradeResultDto>());
        }

        return result;
    }
}