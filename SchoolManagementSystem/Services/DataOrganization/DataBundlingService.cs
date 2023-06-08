using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Models.QuerryResultDtos;
using AdminDto = SchoolManagementSystem.Models.QuerryResultDtos.AdminDto;

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

    public async Task<TeacherDataDto> OrganizeTeacherData(int id)
    {
        var userData = await _userService.FetchUser(id);
        var teacherData = await _userService.FetchTeacher(id);

        if (userData == null || teacherData == null)
            return null;

        var subjects = await _subjectService.GetSubjectsByTeacher(id);
        var students = new Dictionary<string, List<StudentDataDto>>();
        foreach (Subject subject in subjects)
        {
            var studentsBySubject = await _userService.FetchStudentsBySubject(subject.Id);
            var formattedStudents = studentsBySubject.Select(student => new StudentDataDto()
            {
                Name = student.User.Name,
                StudentId = student.StudentId,
                Specialty = student.Specialty.Name
            }).ToList();
            students.Add(subject.Name, formattedStudents);
        }

        var result = new TeacherDataDto()
        {
            Name = userData.Name,
            Id = teacherData.TeacherId,
            Students = students
        };
        return result;
    }

    public async Task<AdminDto?> OrganizeAdminData(int id)
    {
        var userData = await _userService.FetchUser(id);
        var studentData = await _userService.FetchAdmin(id);
        if (userData == null || studentData == null)
            return null;
        return new AdminDto()
        {
            Name = userData.Name,
            Id = userData.UserId
        };
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

    public async Task<TeacherDataDto> OrganizeTeacherGradeData(int id)
    {
        var userData = await _userService.FetchUser(id);
        var teacherData = await _userService.FetchTeacher(id);

        if (userData == null || teacherData == null)
            return null;

        var subjects = await _subjectService.GetSubjectsByTeacher(id);
        var students = new Dictionary<string, List<StudentDataDto>>();
        foreach (Subject subject in subjects)
        {
            var studentsBySubject = await _userService.FetchStudentsBySubject(subject.Id);
            var formattedStudents = studentsBySubject.Select(student => new StudentDataDto()
            {
                Name = student.User.Name,
                Specialty = student.Specialty.Name
            }).ToList();
            students.Add(subject.Name, formattedStudents);
        }

        var result = new TeacherDataDto()
        {
            Name = userData.Name,
            Id = teacherData.TeacherId,
            Students = students
        };
        return result;
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