using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Services.DataOrganization;

public class GradeValue
{
    public readonly string Subject;
    public readonly float Value;
    public GradeValue(string subject, float value)
    {
        Subject = subject;
        Value = value;
    }
}
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
    /// <summary>
    /// Organized the student data from the data layer into a single object
    /// </summary>
    /// <param name="id">StudentId</param>
    /// <returns>StudentDataDto containing the data of the student</returns>
     public async Task<StudentDataDto?> OrganizeStudentData(int id)
    {
        var userData = await _userService.FetchUser(id);
        var studentData = await _userService.FetchStudent(id);
        if (userData == null || studentData == null)
            return null;
        
        var grades = await GetStudentGrades(userData.UserId);
        if (grades.Count == 0)
        {
            var subjects = await _subjectService.GetSubjectsByStudent(studentData.Major.Id);
            return new StudentDataDto   
            {
                StudentId = studentData.StudentId,
                Name = userData.GetFullName(),
                Faculty = studentData.Faculty.Name,
                Course = studentData.Course,
                Specialty = studentData.Major.Name,
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

        var gradeValues = GetGradeValues(grades);
        // var average = gradeValues.Select(g => g.Value).Average();
        var average = CalculateAverageGrade(gradeValues);

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
            Name = $"{userData.FirstName} {userData.LastName}",
            Faculty = studentData.Faculty.Name,
            Course = studentData.Course,
            Specialty = studentData.Major.Name,
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
    /// <summary>
    ///  Returns all the data about the student's grades organized into a single object
    /// </summary>
    /// <param name="id">Student id</param>
    /// <returns>Object containing the regular, term and yearly grades of the student</returns>
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
    /// <summary>
    /// Calculates the average grade of the student 
    /// </summary>
    /// <param name="grades">A collection of key-value pairs containing the subject and the numeric value of the grade</param>
    /// <returns>A float presenting the average grade</returns>
     public float CalculateAverageGrade(IEnumerable<GradeValue> grades) => grades.Select(g => g.Value).Average();
     /// <summary>
     /// Extracts the numeric value of the grade from a list of Grade objects
     /// </summary>
     /// <param name="grades">List of grade objects</param>
     /// <returns>A list of key-value pairs containing the subject and the numeric value of the grade</returns>
     public List<GradeValue> GetGradeValues(List<Grade> grades) =>
         grades.Select(g => new GradeValue(g.Subject.Name, g.Value)).ToList();
     /// <summary>
     /// Fetches the grades of the student from the data layer 
     /// </summary>
     /// <returns>List with the student grades</returns>
     public async Task<List<Grade>> GetStudentGrades(int studentId) =>
         await _gradingService.GetGradesByStudentId(studentId);
}