using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Services;

public class AuthenticationManager
{
    private readonly IConfiguration _config;

    public AuthenticationManager(IConfiguration configuration)
    {
        _config = configuration;
    }
    public void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
    {
        passwordSalt = BCrypt.Net.BCrypt.GenerateSalt(12);
        passwordHash = BCrypt.Net.BCrypt.HashPassword(password, passwordSalt);
    }

    public bool VerifyPasswordHash(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
    public string CreateAuthenticationToken(LoginUserDto user, string role)
    {
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.Role, role), 
        };
        var key = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(_config.GetSection("Authentication:Token").Value));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: credentials);
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}