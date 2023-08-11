using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Services.DataOrganization;

public class TeacherDataBundler:ITeacherDataBundler
{

    private readonly ISubjectService _subjectService;
    private readonly IUserManagementService _userService;

    public TeacherDataBundler(ISubjectService subjectService, IUserManagementService userService)
    {
        _subjectService = subjectService;
        _userService = userService;
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
                Name = student.User.GetFullName(),
                StudentId = student.StudentId,
                Specialty = student.Major.Name
            }).ToList();
            students.Add(subject.Name, formattedStudents);
        }

        var result = new TeacherDataDto()
        {
            Name = userData.GetFullName(),
            Id = teacherData.TeacherId,
            Students = students
        };
        return result;
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
                Name = student.User.GetFullName(),
                Specialty = student.Major.Name
            }).ToList();
            students.Add(subject.Name, formattedStudents);
        }

        var result = new TeacherDataDto()
        {
            Name = userData.GetFullName(),
            Id = teacherData.TeacherId,
            Students = students
        };
        return result;
    }
}