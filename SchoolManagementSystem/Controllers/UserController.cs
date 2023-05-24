using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserManagementService _userManagementService;
    private readonly IAuthenticationManager _authManager;
    private readonly IDataBundlingService _dataBundler;
    public UserController(IUserManagementService userManagementService,
        IAuthenticationManager authManager,
        IDataBundlingService dataBundler
        )
    {
        _userManagementService = userManagementService;
        _authManager = authManager;
        _dataBundler = dataBundler;
    }

    // GET: api/User/5
    [HttpPost("login")]
    public async Task<ActionResult<object>> Login(LoginUserDto request)
    {
        var user = await _userManagementService.AttemptLogin(request);

        if (user == null)
            return NotFound();
        
        var encryptedToken = _authManager.CreateAuthenticationToken(request, user.Role, user.UserId);
        HttpContext.Response.Cookies.Append("token", encryptedToken, new CookieOptions
        {
            Expires = DateTime.UtcNow.AddHours(2),
            HttpOnly = true,
            Secure = true,
            Domain = "localhost",
            IsEssential = true,
            SameSite = SameSiteMode.None,
        });
        return Ok( new
            {
                UserId = user.UserId, 
                UserRole = user.Role,
                
            }
        );
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

    [Authorize("Student,Admin,Teacher")]
    [HttpGet("Student")]
    public async Task<ActionResult<StudentDataDto>> GetStudentData()
    {
        var userCredentials = _authManager.ParseToken(HttpContext.Request.Cookies["token"]);
        if (userCredentials == null)
            return StatusCode(502);
        int studentId = int.Parse(userCredentials["userId"]);
        var result = await _dataBundler.OrganizeStudentData(studentId);
        return Ok(result);
    }
}