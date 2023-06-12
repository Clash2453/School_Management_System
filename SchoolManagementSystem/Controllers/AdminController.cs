using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
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
    private readonly IEmailService _emailService;

    public AdminController(IUserManagementService userManagementService, IEmailService emailService)
    {
        _userManagementService = userManagementService;
        _emailService = emailService;
    }
    
    [Authorize(Roles = "Admin")]
    [HttpGet("guests")]
    public async Task<IActionResult> FetchGuests()  
    {
        return Ok(await _userManagementService.FetchGuests());
    }
    [Authorize(Roles = "Admin")]
    [HttpGet("fetch/teachers")]
    public async Task<IActionResult> FetchTeachers()  
    {
        return Ok(await _userManagementService.FetchTeachers());
    }
    [HttpPost("approve/student")]
    public async Task<IActionResult> AssignStudent(StudentDto request)
    {
        var status = await _userManagementService.CreateStudent(request);
        _emailService.SendMail(new EmailDto()
        {    
            Receiver = request.Email,
            Body = "Your application has been approved by an administrator. You have access to the system.",
            Subject = "Application approval"

        });
        if (status == Status.Fail )
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
    [HttpPost("email")]
    public IActionResult SendEmail(EmailDto request)
    {
        var status = _emailService.SendMail(request);
        if (status == Status.Fail)
            return StatusCode(500);
        return Ok("Email sent successfully");
    }
 
    [HttpDelete("delete-user")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var status = await _userManagementService.DeleteUser(id);
        if (status == Status.Fail)
            return StatusCode(500);

        return Ok("User deleted successfully");
    }

}