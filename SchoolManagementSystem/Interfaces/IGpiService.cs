using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Models.QuerryResultDtos;
using SchoolManagementSystem.Services.DataOrganization;

namespace SchoolManagementSystem.Interfaces;

public interface IGpiService
{
    public double CalculateStudentGpi(float avgGrade, GradingSystem gradingSystem);
    public double CalculateStudentGpi(string avgGrade, GradingSystem gradingSystem);
    public double CalculateExamGpi(List<GradeValue> examGrades);
    public double CalculateAcademicGpi(float averageFloat, GradingSystem gradingSystem);
}