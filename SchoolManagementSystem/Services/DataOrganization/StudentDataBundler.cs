using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Services.DataOrganization;

public class StudentDataBundler: IStudentDataBundler
{
    private readonly IGradingService _gradingService;
    private readonly IAbsenceService _absenceService;
    private readonly ISubjectService _subjectService;
    private readonly IUserManagementService _userService;

    public StudentDataBundler(IGradingService gradingService,
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
        if (userData == null || studentData == null)
            return null;
        
        var grades = await _gradingService.GetGradesByStudentId(userData.UserId);
        if (grades.Count == 0)
        {
            var subjects = await _subjectService.GetSubjectsByStudent(studentData.Specialty.SpecialtyId);
            return new StudentDataDto   
            {
                StudentId = studentData.StudentId,
                Name = userData.Name,
                Faculty = studentData.Faculty.Name,
                Course = studentData.Course,
                Specialty = studentData.Specialty.Name,
                Group = studentData.Group,
                AvgGrade = 6,
                HighestAvgSubject = subjects[0].Name,
                HighestAvg = 6,
                LowestAvgSubject = subjects[0].Name,
                LowestAvg = 6,
                TotalAbsence = 0,
                ExcusedAbsence = 0,
                UnExcusedAbsence = 0
            };  
        }
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
        
        var absences = await _absenceService.GetAbsenceByStudent(userData.UserId);
        var totalAbsence = absences.Count;
        var excusedAbsence = absences.Count(s => s.Excused);
        var unExcusedAbsence = absences.Count - excusedAbsence;
        var response = new StudentDataDto   
        {
            StudentId = studentData.StudentId,
            Name = userData.Name,
            Faculty = studentData.Faculty.Name,
            Course = studentData.Course,
            Specialty = studentData.Specialty.Name,
            Group = studentData.Group,
            AvgGrade = average,
            HighestAvgSubject = max.Subject,
            HighestAvg = max.AverageGrade,
            LowestAvgSubject = min.Subject,
            LowestAvg = min.AverageGrade,
            TotalAbsence = totalAbsence,
            ExcusedAbsence = excusedAbsence,
            UnExcusedAbsence = unExcusedAbsence
        };
        return response;
    }
     public async Task<GradeDataDto?> OrganizeStudentGradeData(int id)
     {
         var userData = await _userService.FetchUser(id);
         var studentData = await _userService.FetchStudent(id);
         if (userData == null || studentData == null)
             return null;
         var grades = await _gradingService.GetGradesByStudentId(userData.UserId);

         if (grades.Count == 0)
             return new GradeDataDto();
         var groupedGrades = grades.Select(g =>
                 new GradeResultDto()
                 {
                     Subject = g.Subject.Name,
                     Value = g.Value,
                     Course = g.StudentYear,
                     Term = g.Term,
                     Date = new DateTime(g.Date.Year, g.Date.Month, g.Date.Day),
                     Type = g.TypeOfGrade.ToString()

                 })
             .GroupBy(g => g.Type)
             .Select(g => g.ToList())
             .ToList();


         return new GradeDataDto
         {
             Grades = groupedGrades,
         };
     }
}