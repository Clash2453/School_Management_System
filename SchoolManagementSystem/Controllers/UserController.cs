using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserManagementService _userManagementService;
    private readonly IAuthenticationManager _authManager;
    public UserController(IUserManagementService userManagementService, IAuthenticationManager authManager)
    {
        _userManagementService = userManagementService;
        _authManager = authManager;
    }

    // GET: api/User/5
    [HttpPost("login")]
    public async Task<ActionResult<LoginResultDto>>Login(LoginUserDto request)
    {
        var user = await _userManagementService.AttemptLogin(request);

        if (user == null)
            return NotFound();
        
        var encryptedToken = _authManager.CreateAuthenticationToken(request, user.Role);
        HttpContext.Response.Cookies.Append("token", encryptedToken, new CookieOptions
        {
            Expires = DateTime.UtcNow.AddHours(2),
            HttpOnly = true,
            Secure = true,
            Domain = "localhost",
            IsEssential = true,
            SameSite = SameSiteMode.None,
        });
        var result = new LoginResultDto()
        {
            UserId = user.UserId,
            UserRole = user.Role
        };
        return Ok(result);
    }
    // POST: api/User
    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(UserDto request)
    {

        var result = await _userManagementService.CreateUser(request);
        if (result == Status.Fail)
            return StatusCode(502);
        
        return CreatedAtAction("Register", "Registered user");
    }
}