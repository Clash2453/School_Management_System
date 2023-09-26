using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Models.QuerryResultDtos;
namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;
        private readonly IAuthenticationManager _authManager;
        private readonly ITeacherDataBundler _teacherDataBundler;
        private readonly IStudentDataBundler _studentDataBundler;
        private readonly IAdminDataBundler _adminDataBundler;
        private readonly IFileService _fileService;

        public UserController(IUserManagementService userManagementService,
            IAuthenticationManager authManager,
            ITeacherDataBundler teacherDataBundler,
            IStudentDataBundler studentDataBundler,
            IAdminDataBundler adminDataBundler,
            IFileService fileService
        )
        {
            _userManagementService = userManagementService;
            _authManager = authManager;
            _teacherDataBundler = teacherDataBundler;
            _studentDataBundler = studentDataBundler;
            _adminDataBundler = adminDataBundler;
            _fileService = fileService;
        }

        /// <summary>
        /// Logs in a user.
        /// </summary>
        /// <param name="request">LoginUserDto containing user credentials.</param>
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
            return Ok(new
            {
                UserId = user.UserId,
                UserRole = user.Role,
            });
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="request">UserDto containing user information.</param>
        [HttpPost("guests")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            if (request.Password != request.ConfirmPassword)
                return BadRequest();

            var result = await _userManagementService.CreateUser(request);
            if (result == Status.Fail)
                return StatusCode(502);

            return CreatedAtAction("Register", "Registered user");
        }

        /// <summary>
        /// Retrieves data for a student if the user is authenticated as a Student, Admin, or Teacher.
        /// </summary>
        [Authorize(Roles = "Student,Admin,Teacher")]
        [HttpGet("students")]
        public async Task<ActionResult<StudentDataDto>> GetStudentData()
        {
            var userCredentials = _authManager.ParseToken(HttpContext.Request.Cookies["token"]);
            if (userCredentials == null)
                return StatusCode(502);
            int studentId = int.Parse(userCredentials["id"]);
            var result = await _studentDataBundler.OrganizeStudentData(studentId);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves data for a teacher if the user is authenticated as an Admin or Teacher.
        /// </summary>
        [Authorize(Roles = "Admin,Teacher")]
        [HttpGet("teachers")]
        public async Task<ActionResult<TeacherDataDto>> GetTeacherData()
        {
            var userCredentials = _authManager.ParseToken(HttpContext.Request.Cookies["token"]);
            if (userCredentials == null)
                return StatusCode(502);
            int studentId = int.Parse(userCredentials["id"]);
            var result = await _teacherDataBundler.OrganizeTeacherData(studentId);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves data for an admin if the user is authenticated as an Admin.
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet("admins")]
        public async Task<ActionResult<AdminResultDto>> GetAdminData()
        {
            var userCredentials = _authManager.ParseToken(HttpContext.Request.Cookies["token"]);
            if (userCredentials == null)
                return StatusCode(502);
            int studentId = int.Parse(userCredentials["id"]);
            var result = await _adminDataBundler.OrganizeAdminData(studentId);
            return Ok(result);
        }

        /// <summary>
        /// Uploads a user's profile picture.
        /// </summary>
        /// <param name="userFile">The user's profile picture file.</param>
        [HttpPost("profile-pictures")]
        public async Task<ActionResult> PostProfilePicture(IFormFile userFile)
        {
            var userCredentials = _authManager.ParseToken(HttpContext.Request.Cookies["token"]);
            if (userCredentials == null)
                return StatusCode(502);
            int userId = int.Parse(userCredentials["id"]);
            var result = await _fileService.UploadFileAsync(userFile, userId);

            if (result == Status.Fail)
                return new BadRequestResult();

            return Ok("Profile picture successfully updated");
        }

        /// <summary>
        /// Retrieves the user's profile picture.
        /// </summary>
        [HttpGet("profile-pictures")]
        public async Task<ActionResult> GetProfilePicture()
        {
            var userCredentials = _authManager.ParseToken(HttpContext.Request.Cookies["token"]);
            if (userCredentials == null)
            {
                return StatusCode(404);
            }
            int id = int.Parse(userCredentials["id"]);
            return Ok(await _fileService.GetProfilePicture(id));
        }

        /// <summary>
        /// Updates the user's profile.
        /// </summary>
        [HttpPut("users")]
        public async Task<ActionResult> UpdateProfile()
        {
            return Ok("Data edited successfully");
        }
    }
}
