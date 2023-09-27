using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Interfaces;

public interface ISubjectService
{
    //CRUD
    public Task<Status> CreateSubject(SubjectDto request);
    public Task<Status> AddMajor (MajorDto request);
    public Task<Faculty?> GetFaculty(int facultyId);
    public Task<Status> AddFaculty(FacultyDto request);
    public Task<List<SubjectDto>?> GetAllSubjects();
    public Task<List<MajorQueryResult>?> GetAllMajors();
    public Task<List<FacultyQueryResult>?> GetAllFaculties();
    public Task<Status> RemoveSpecialty(int specialtyId);
    public Task<Status> RemoveFaculty(int facultyId);
    public Task<Status> UpdateSubject(SubjectDto request);
    public Task<Status> RemoveSubject(int id);
    //retrieval functions
    public Task<List<Subject>> GetSubjectsByStudent(int studentId);
    public Task<List<Subject>> GetSubjectsByTeacher(int teacherId);
    public Task<Subject?> GetSubjectById(int subjectId);
    Task<Status> GetMajor(MajorDto request);
}