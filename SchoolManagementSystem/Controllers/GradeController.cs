
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Models.QuerryResultDtos;
using SchoolManagementSystem.Services;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles = "Teacher,Admin")]
    public class GradeController : ControllerBase
    {
        private readonly IGradingService _gradingService;
        private readonly IAuthenticationManager _authManager;
        private readonly ITeacherDataBundler _teacherDataBundler;
        private readonly IStudentDataBundler _studentDataBundler;
        private readonly IGradeDataBundler _gradeDataBundler;
        public GradeController(IGradingService gradingService, 
            IAuthenticationManager authManager,
            ITeacherDataBundler teacherDataBundler,
            IStudentDataBundler studentDataBundler,
            IGradeDataBundler gradeDataBundler  
            )
        {
            _gradingService = gradingService;
            _authManager = authManager;
            _teacherDataBundler = teacherDataBundler;
            _studentDataBundler = studentDataBundler;
            _gradeDataBundler = gradeDataBundler;
        }
        /// <summary>
        /// Gets the grades of a student
        /// </summary>
        [HttpGet("student-grades")] 
        [Authorize(Roles="Student,Admin")]
        public async Task<ActionResult<GradeDto>> GetStudentGrades()
        {
            var userCredentials = _authManager.ParseToken(HttpContext.Request.Cookies["token"]);
            if (userCredentials == null)
                return StatusCode(502);
            int studentId = int.Parse(userCredentials["id"]);

            var grades = await _studentDataBundler.OrganizeStudentGradeData(studentId);
          if(grades == null)
              return StatusCode(418); //¯\_(ツ)_/¯   

          return Ok(grades);
        }
        /// <summary>
        /// Gets the grades grouped with the respective subject for a student
        /// </summary>
        [HttpGet("subjects-grades")]
        [Authorize(Roles="Student,Admin")]
        public async Task<ActionResult<Dictionary<string, List<GradeResultDto>>>> GetStudentGradesAndSubjects()
        {
            var userCredentials = _authManager.ParseToken(HttpContext.Request.Cookies["token"]);
            if (userCredentials == null)
                return StatusCode(502);
            int studentId = int.Parse(userCredentials["id"]);

            var grades = await _gradeDataBundler.OrganizeGradesPerSubjects(studentId);
            if(grades == null)
                return StatusCode(418); //¯\_(ツ)_/¯   

            return Ok(grades);
        }
        /// <summary>
        /// Get the grades of a teacher
        /// </summary>
        [HttpGet("teacher-grades")] 
        [Authorize(Roles="Teacher,Admin")]
        public async Task<ActionResult<GradeDto>> GetTeacherGrades()
        {
            var userCredentials = _authManager.ParseToken(HttpContext.Request.Cookies["token"]);
            if (userCredentials == null)
                return StatusCode(502);
            int teacherId = int.Parse(userCredentials["id"]);

            var grades = await _teacherDataBundler.OrganizeTeacherGradeData(teacherId);
            if(grades == null)
                return StatusCode(418); //¯\_(ツ)_/¯

            return Ok(grades);
        }
        /// <summary>
        /// Adds a new grade
        /// </summary>
        /// <param name="request">GradeDto object with the grade data</param>
        [HttpPost("grades")]
        [Authorize(Roles="Teacher,Admin")]
        public async Task<ActionResult<Grade>> AddGrade(GradeDto request)
        {
            var userCredentials = _authManager.ParseToken(HttpContext.Request.Cookies["token"]);
            if (userCredentials == null)
                return StatusCode(502);
            int teacherId = int.Parse(userCredentials["id"]);
            var status = await _gradingService.AddGrade(request, teacherId); 
            
            if(status == Status.Fail)
              return StatusCode(418); //¯\_(ツ)_/¯
            
            return Ok("Grade added successfully");
        }
        /// <summary>
        /// Delete a grade by id
        /// </summary>
        /// <param name="id">The id of the grade that needs to be deleted</param>
        [HttpDelete("grades")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var status = await _gradingService.DeleteGrade(id);
            if(status == Status.Fail)
                return StatusCode(418); //¯\_(ツ)_/¯

            return Ok();
        }
    }
}
