using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Services;
using AuthenticationManager = SchoolManagementSystem.Services.AuthenticationManager;

namespace SchoolManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly SchoolDbContext _context;
    private readonly AuthenticationManager _authManager;
    private readonly UserCreationService _userFactory;

    public UserController(SchoolDbContext context, IConfiguration config)
    {
        _context = context;
        _authManager = new AuthenticationManager(config);
        _userFactory = new UserCreationService(_authManager);
    }

    // GET: api/User/5
    [HttpPost("login")]
    public async Task<ActionResult<LoginUserDto>> Login(LoginUserDto request)
    {
        if (_context.Users == null) return NotFound();

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user == null)
            return Unauthorized("Wrong email");

        if (!_authManager.VerifyPasswordHash(request.Password, user.Password))
            return Unauthorized("Wrong password");

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
        return Ok();
    }

    // PUT: api/User/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("update")]
    [Authorize( Roles = "Admin")]

    public async Task<IActionResult> Update(LoginUserDto request)
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(request.Email))
                return NotFound();
            else
                throw;
        }

        return Ok();
    }

    // POST: api/User
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(UserDto request)
    {
        if (_context.Users == null) return Problem("Entity set 'SchoolDbContext.Users'  is null.");

        if (UserExists(request.Email))
            return Conflict("User already exists");
        var user = _userFactory.CreateUser(request);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Register", "Registered user");
    }

    private bool UserExists(string email)
    {
        return (_context.Users?.Any(e => e.Email == email)).GetValueOrDefault();
    }
}