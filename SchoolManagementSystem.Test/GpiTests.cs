using System.Globalization;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Services.DataOrganization;
using Xunit.Abstractions;

namespace SchoolManagementSystem.Test;
public class GpiCalculatorTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly GpiService _gpiCalculator;

    public GpiCalculatorTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _gpiCalculator = new GpiService();
    }

    [Theory]
    [InlineData(75.0f, GradingSystem.PercentageGrading, 75.0)] // 75% should be converted to 75.0 on the 100-point scale
    [InlineData(80.0f, GradingSystem.BulgarianGrading, -1.0)] // Invalid conversion from Bulgarian Grading to 100-point scale since Bulgarian Grading scale is not provided
    [InlineData(3.5f, GradingSystem.BulgarianGrading, 37.5)]  // 3.5 in Bulgarian Grading should be converted to approximately 37.5 on the 100-point scale
    [InlineData(4.5f, GradingSystem.BulgarianGrading, 62.5)]  // 4.5 in Bulgarian Grading should be converted to approximately 62.5 on the 100-point scale
    [InlineData(6.0f, GradingSystem.BulgarianGrading, 100.0)] // 6.0 in Bulgarian Grading should be converted to 100.0 on the 100-point scale
    [InlineData(5.5f, GradingSystem.BulgarianGrading, 87.5)]  // 5.5 in Bulgarian Grading should be converted to approximately 87.5 on the 100-point scale
    [InlineData(2.0f, GradingSystem.BulgarianGrading, 0.0)]  // 2.0 in Bulgarian Grading should be converted to 0.0 on the 100-point scale
    [InlineData(5.7f, GradingSystem.BulgarianGrading, 92.5)]  // 5.7 in Bulgarian Grading should be converted to approximately 92.5 on the 100-point scale
    public void CalculateAcademicGpi_Should_ConvertTo100PointScale(float averageFloat, GradingSystem gradingSystem, double expectedConvertedScore)
    {
        // Act
        double actualConvertedScore = _gpiCalculator.CalculateAcademicGpi(averageFloat, gradingSystem);
        // Assert
        Assert.Equal(expectedConvertedScore, actualConvertedScore, 2);
    }

    [Fact]
    public void CalculateAcademicGpi_Should_ReturnMinusOneForInvalidGradingSystem()
    {
        // Arrange
        float averageFloat = 80.0f;
        GradingSystem invalidGradingSystem = (GradingSystem)999; // An invalid grading system value

        // Act
        double actualConvertedScore = _gpiCalculator.CalculateAcademicGpi(averageFloat, invalidGradingSystem);

        // Assert
        Assert.Equal(-1, actualConvertedScore);
    }
}