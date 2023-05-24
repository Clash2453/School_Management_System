using SchoolManagementSystem.Data;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Models.IntermediateTables;

namespace SchoolManagementSystem.Services.DataManipulation;

public class SubjectService : ISubjectService
{
    private readonly SchoolDbContext _context;
    public SubjectService(SchoolDbContext context)
    {
        _context = context;
    }
    public async Task<Status> CreateSubject(SubjectDto request)
    {
        var subject = new Subject()
        {
            Name = request.Name,
        };
        List<StudentSubject> studentSubjects = new List<StudentSubject>();
        List<TeacherSubject> teacherSubjects = new List<TeacherSubject>();
        
        foreach (var studentId in request.StudentIds)
        {
            StudentSubject intermid = new StudentSubject()
            {
                Subject = subject,
                Student = new Student()
                {
                    StudentId = studentId
                }
            };
            studentSubjects.Add(intermid);
        }

        foreach (int teacherId in request.TeacherIds)
        {
            TeacherSubject intermid = new TeacherSubject()
            {
                Subject = subject,
                Teacher = new Teacher()
                {
                    TeacherId = teacherId
                }
            };
            teacherSubjects.Add(intermid);
        }
        _context.StudentSubjects.AttachRange(studentSubjects);
        _context.TeacherSubjects.AttachRange(teacherSubjects);
        _context.Subjects.Add(subject);

        await _context.SaveChangesAsync();
        return Status.Success;
    }

    public async Task<Status> UpdateSubject(SubjectDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<Status> RemoveSubject(int id)
    {
        var subject = _context.Subjects.Find(id);
        if (subject == null)
            return Status.Fail;
        
        _context.Subjects.Remove(subject);
        await _context.SaveChangesAsync();
        return Status.Success;
    }

    public async Task<List<Subject>> GetSubjectsByStudent(int studentId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Subject>> GetSubjectsByTeacher(int teacherId)
    {
        throw new NotImplementedException();
    }

    public async Task<Subject> GetSubjectById(int subjectId)
    {
        throw new NotImplementedException();
    }
}