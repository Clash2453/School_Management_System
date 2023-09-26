using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Services.DataManipulation;

public class AuthenticationManager : IAuthenticationManager
{
    private readonly IConfiguration _config;

    public AuthenticationManager(IConfiguration configuration)
    {
        _config = configuration;
    }
    /// <summary>
    /// Creates Hash for the password using the BCrypt algorithm
    /// </summary>
    /// <param name="password">The password the user has entered</param>
    /// <param name="passwordHash">The generated password hash generated</param>
    /// <param name="passwordSalt">The generated password salt </param>
    public void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
    {
        passwordSalt = BCrypt.Net.BCrypt.GenerateSalt(12);
        passwordHash = BCrypt.Net.BCrypt.HashPassword(password, passwordSalt);
    }
    /// <summary>
    /// Verifies a password against its hash to check whether the password is correct or not
    /// </summary>
    /// <param name="password">The user password</param>
    /// <param name="passwordHash">The hash we are checking</param>
    /// <returns></returns>
    public bool VerifyPasswordHash(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
    /// <summary>
    /// Generates a JWT authentication token for the user in order to track session and authorize actions
    /// </summary>
    /// <param name="user">LoginDTO containing the data of the user</param>
    /// <param name="role">The role of the user in the system's hierarchy</param>
    /// <param name="id">The id of the user</param>
    /// <returns>The JWT token in the form of string</returns>
    public string CreateAuthenticationToken(LoginUserDto user, string role, int id)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email,user.Email, "email"),
            new Claim(ClaimTypes.Role, role, "role"),
            new Claim(ClaimTypes.NameIdentifier, id.ToString(), "userId")
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
    /// <summary>
    /// Parses the JWT token in order to extract the user data from it
    /// </summary>
    /// <param name="tokenString">The JWT token of the user</param>
    /// <returns>Dictionary with the properties in the token </returns>
    public Dictionary<string, string> ParseToken(string? tokenString)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadJwtToken(tokenString);
        var claims = token.Claims;
        var claimsArray = claims as Claim[] ?? claims.ToArray();
        var userEmail = claimsArray.First(c => c.Type == ClaimTypes.Email).Value;
        var userId = claimsArray.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var userRole = claimsArray.First(c => c.Type == ClaimTypes.Role).Value;
        Dictionary<string, string> result = new();
        result.Add("id", userId);
        result.Add("role", userRole);
        result.Add("email", userEmail);
        return result;
    }
}