using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly IUserManagementService _userManagementService;

    public AdminController(IUserManagementService userManagementService)
    {
        _userManagementService = userManagementService;
    }
    
    [Authorize(Roles = "Admin")]
    [HttpGet("guests")]
    public async Task<IActionResult> FetchGuests()  
    {
        return Ok(await _userManagementService.FetchGuests());
    }

    [HttpPost("approve/student")]
    public async Task<IActionResult> AssignStudent(StudentDto request)
    {
        var status = await _userManagementService.CreateStudent(request);
        if (status == Status.Fail)
            return StatusCode(500);

        return Ok("Student added successfully");
    }

    [HttpPost("approve/teacher")]
    public async Task<IActionResult> AssignTeacher(TeacherDto request)
    {
        var status = await _userManagementService.CreateTeacher(request);
        if (status == Status.Fail)
            return StatusCode(500);

        return Ok("Teacher added successfully");
    }

    [HttpPost("approve/admin")]
    public async Task<IActionResult> AssignAdmin(AdminDto request)
    {
        var status = await _userManagementService.CreateAdmin(request);
        if (status == Status.Fail)
            return StatusCode(500);

        return Ok("Admin added successfully");
    }
 
    [HttpDelete("admin/delete-user")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var status = await _userManagementService.DeleteUser(id);
        if (status == Status.Fail)
            return StatusCode(500);

        return Ok("Admin added successfully");
    }
}