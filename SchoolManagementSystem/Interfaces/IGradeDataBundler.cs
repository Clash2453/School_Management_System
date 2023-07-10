using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Interfaces;

public interface IGradeDataBundler
{
    public Task<Dictionary<string, List<GradeResultDto>>?> OrganizeGradesPerSubjects(int id);
}