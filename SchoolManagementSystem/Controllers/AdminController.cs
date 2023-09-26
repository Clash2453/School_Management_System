using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Models.QuerryResultDtos;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
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

        /// <summary>
        /// Retrieves a list of guest users.
        /// </summary>
        [HttpGet("guests")]
        public async Task<IActionResult> FetchGuests()
        {
            return Ok(await _userManagementService.FetchGuests());
        }

        /// <summary>
        /// Retrieves a list of all teachers.
        /// </summary>
        [HttpGet("teachers")]
        public async Task<IActionResult> FetchTeachers()
        {
            var result = await _adminDataBundler.FetchAllTeachers();
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a list of all students.
        /// </summary>
        [HttpGet("students")]
        public async Task<ActionResult<UserResultDto>> FetchStudents()
        {
            var result = await _adminDataBundler.FetchAllStudents();
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a list of all admins.
        /// </summary>
        [HttpGet("admins")]
        public async Task<IActionResult> FetchAdmins()
        {
            var result = await _adminDataBundler.FetchAllAdmins();
            return Ok(result);
        }

        /// <summary>
        /// Approves and assigns a student role.
        /// </summary>
        /// <param name="request">StudentDto containing student information.</param>
        [HttpPost("student")]
        public async Task<IActionResult> AssignStudent(StudentDto request)
        {
            var status = await _userManagementService.CreateStudent(request);
            _emailService.SendMail(new EmailDto()
            {
                Receiver = request.Email,
                Body = "Your application has been approved by an administrator. You have access to the system.",
                Subject = "Application approval"
            });

            if (status == Status.Fail)
                return StatusCode(500);

            return Ok("Student added successfully");
        }

        /// <summary>
        /// Approves and assigns a teacher role.
        /// </summary>
        /// <param name="request">TeacherDto containing teacher information.</param>
        [HttpPost("teachers")]
        public async Task<IActionResult> AssignTeacher(TeacherDto request)
        {
            var status = await _userManagementService.CreateTeacher(request);

            if (status == Status.Fail)
                return StatusCode(500);

            return Ok("Teacher added successfully");
        }

        /// <summary>
        /// Approves and assigns an admin role.
        /// </summary>
        /// <param name="request">AdminDto containing admin information.</param>
        [HttpPost("admins")]
        public async Task<IActionResult> AssignAdmin(AdminDto request)
        {
            var status = await _userManagementService.CreateAdmin(request);

            if (status == Status.Fail)
                return StatusCode(500);

            return Ok("Admin added successfully");
        }

        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="request">EmailDto containing email details.</param>
        [HttpPost("emails")]
        public IActionResult SendEmail(EmailDto request)
        {
            var status = _emailService.SendMail(request);

            if (status == Status.Fail)
                return StatusCode(500);

            return Ok("Email sent successfully");
        }

        /// <summary>
        /// Deletes a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to be deleted.</param>
        [HttpDelete("users")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var status = await _userManagementService.DeleteUser(id);

            if (status == Status.Fail)
                return StatusCode(500);

            return Ok("User deleted successfully");
        }
    }
}
