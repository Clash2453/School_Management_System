using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Interfaces;

public interface ISubjectService
{
    //CRUD
    public Task<Status> CreateSubject(SubjectDto request);
    public Task<Status> UpdateSubject(SubjectDto request);
    public Task<Status> RemoveSubject(int id);
    //retrieval functions
    public Task<List<Subject>> GetSubjectsByStudent(int studentId);
    public Task<List<Subject>> GetSubjectsByTeacher(int teacherId);
    public Task<Subject> GetSubjectById(int subjectId);
}