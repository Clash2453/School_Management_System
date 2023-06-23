using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly IUserManagementService _userManagementService;
    private readonly IEmailService _emailService;
    private readonly IAdminDataBundler _adminDataBundler;
    public AdminController(IUserManagementService userManagementService, IEmailService emailService, IAdminDataBundler adminDataBundler)
    {
        _userManagementService = userManagementService;
        _emailService = emailService;
        _adminDataBundler = adminDataBundler; 
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
        var result = await _adminDataBundler.FetchAllTeachers();
        return Ok(result);
    }
    [Authorize(Roles = "Admin")]
    [HttpGet("fetch/students")]
    public async Task<ActionResult<UserResultDto>> FetchStudents()  
    {
        var result = await _adminDataBundler.FetchAllStudents();
        return Ok(result);
    }
    [Authorize(Roles = "Admin")]
    [HttpGet("fetch/admins")]
    public async Task<IActionResult> FetchAdmins()  
    {
        var result = await _adminDataBundler.FetchAllAdmins();
        return Ok(result);
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