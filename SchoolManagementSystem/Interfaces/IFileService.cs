using SchoolManagementSystem.Enums;

namespace SchoolManagementSystem.Interfaces;

public interface IFileService
{
    public Task<Status> UploadFileAsync(IFormFile profilePicture, int id);
    public Task<string> GetProfilePicture(int userId);
}