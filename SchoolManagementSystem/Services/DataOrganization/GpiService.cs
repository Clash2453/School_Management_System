using System.Diagnostics;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Services.DataOrganization;

public class GpiService : IGpiService
{
    private readonly IUserManagementService _userManagementService;
    private readonly IStudentDataBundler _studentDataBundler;
    public GpiService(IUserManagementService userManagementService, IStudentDataBundler studentDataBundler)
    {
        _userManagementService = userManagementService;
        _studentDataBundler = studentDataBundler;
    }

    private double CalculateAcademicGpi(string average, GradingSystem gradingSystem)
    {
        double convertedScore = 100;
        switch (gradingSystem)
        {
            case GradingSystem.LetterGradingUs:
                // Perform actions specific to Letter Grading (US)
                
                // Define the mapping between letter grades and numerical ranges
                Dictionary<string, double> gradeMappings = new Dictionary<string, double>()
                {
                    { "A+", 97 },
                    { "A", 93 },
                    { "A-", 90 },
                    { "B+", 87 },
                    { "B", 83 },
                    { "B-", 80 },
                    { "C+", 77 },
                    { "C", 73 },
                    { "C-", 70 },
                    { "D+", 67 },
                    { "D", 63 },
                    { "D-", 60 },
                    { "F", 50 }
                };

                // Convert the letter grade to a numerical score on the 100-point scale
                if (gradeMappings.TryGetValue(average, out convertedScore))
                {
                    return convertedScore;
                }
                else
                {
                    // Handle unrecognized letter grade (return a default value or throw an exception)
                    throw new ArgumentException("Unrecognized letter grade.");      
                }

            default:
                return -1;
        }   
    }
    private double CalculateAcademicGpi(float averageFloat, GradingSystem gradingSystem)
    {

        double convertedScore = 100;
        
        switch (gradingSystem)
        {
            case GradingSystem.PercentageGrading:
                // Perform actions specific to Percentage Grading
                
                // Calculate the score on the 100-point scale using linear mapping
                convertedScore = (averageFloat / 100.0) * 100.0;

                return convertedScore;

            case GradingSystem.BulgarianGrading:
                // Perform actions specific to Bulgarian Grading
                
                // Define the minimum and maximum scores on the 2 to 6 grading scale
                double minScore = 2.0;
                double maxScore = 6.0;

                // Define the minimum and maximum scores on the 100-point scale
                double min100Point = 0.0;
                double max100Point = 100.0;

                // Calculate the score on the 100-point scale using linear mapping
                convertedScore = ((averageFloat - minScore) / (maxScore - minScore)) * (max100Point - min100Point) + min100Point;

                return Math.Round(convertedScore, 2);
                
                break;
            default:
                return -1;
                break;
        }
        throw new NotImplementedException();
    }
    private double CalculateAcademicGpi(double globalAvgSuccess, double subjectCredits)
    {
        // Define the weight for the global average success (you can adjust this based on your requirements)
        double globalAvgWeight = 0.4;

        // Define the weight for the subject credits (you can adjust this based on your requirements)
        double creditsWeight = 0.6;

        // Calculate the GPI score using weighted average
        double gpi = (globalAvgSuccess * globalAvgWeight) + (subjectCredits * creditsWeight);

        return gpi;
    }

    
    public StudentGpiDto CalculateStudentGpi(string avgGrade, GradingSystem gradingSystem)
    {
        
        //calculate the overall academic grade of the student/undergrad
        double unifiedGrade = CalculateAcademicGpi(avgGrade, gradingSystem);
        double academicGpi = CalculateAcademicGpi(67, unifiedGrade);
        
        //calculate the examination gpi grade of the student/undergrad
        
        
        throw new NotImplementedException();
    }
    
    public StudentGpiDto CalculateStudentGpi(float avgGrade, GradingSystem gradingSystem)
    {
        
        //calculate the overall academic grade of the student/undergrad
        double unifiedGrade = CalculateAcademicGpi(avgGrade, gradingSystem);
        double academicGpi = CalculateAcademicGpi(67, unifiedGrade);
        
        //calculate the examination gpi grade of the student/undergrad
            
        
        throw new NotImplementedException();
    }
}