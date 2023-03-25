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
            return NotFound("Wrong email");

        if (_authManager.VerifyPasswordHash(request.Password, user.Password, user.Salt))
            return NotFound("Wrong password");
        

        return Ok(_authManager.CreateAuthenticationToken(request, user.Role));
    }

    // PUT: api/User/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut]
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

    // DELETE: api/User/5
    [HttpDelete("{id}")]
    [Authorize( Roles = "Admin")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        if (_context.Users == null) return NotFound();
        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound();

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UserExists(string email)
    {
        return (_context.Users?.Any(e => e.Email == email)).GetValueOrDefault();
    }
}