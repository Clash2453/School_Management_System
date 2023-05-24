using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Interfaces;

public interface IAuthenticationManager
{
    public void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt);
    public bool VerifyPasswordHash(string password, string passwordHash);
    public string CreateAuthenticationToken(LoginUserDto user, string role, int id);
    public Dictionary<string, string>? ParseToken(string token);
}