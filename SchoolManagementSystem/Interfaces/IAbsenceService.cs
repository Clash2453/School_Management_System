using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Interfaces;

public interface IAbsenceService
{
    //Retrieval functions
    public Task<Absence?> GetAbsenceById(int absenceId);
    public Task<List<Absence>> GetAbsenceByStudent(int studentId);
    public Task<List<Absence>> GetAbsenceByTeacher(int teacherId);
    
    //Removal functions
    public Task<Status> RemoveAbsenceById(int absenceId);
    
    //Excusing functions
    public Task<Status> ExcuseAbsenceById(int absenceId);
    public Task<Status> ExcuseAbsences(int studentId, int subjectId, DateTime date);
    
    //Creating functions
    public Task<Status> CreateAbsence(AbsenceDto request);
}