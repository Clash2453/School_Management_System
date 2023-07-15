using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Interfaces;

public interface IGpiService
{
    public Task<StudentGpiDto?> CalculateStudentGpi(float avgGrade);
}