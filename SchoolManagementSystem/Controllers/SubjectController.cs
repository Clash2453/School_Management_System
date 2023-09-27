using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        /// <summary>
        /// Adds a new subject
        /// </summary>
        /// <param name="request">Subject Dto containing the subject data</param>
        [HttpPost("subjects")]
        public async Task<ActionResult<Subject>> PostSubject(SubjectDto request)
        {
            return Ok(await _subjectService.CreateSubject(request));
        }

        /// <summary>
        /// Deletes a subject
        /// </summary>
        /// <param name="id">The id of the subject to be deleted</param>
        [HttpDelete("subjects")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            return Ok(await _subjectService.RemoveSubject(id));
        }
        /// <summary>
        /// Adds a new faculty
        /// </summary>
        [HttpPost("faculties")]
        public async Task<IActionResult> AddFaculty(FacultyDto request)
        {
            var result = await _subjectService.AddFaculty(request);
            if (result == Status.Fail)
                return StatusCode(500);
            return Ok();
        }
        /// <summary>
        /// Adds a new major
        /// </summary>
        [HttpPost("majors")]
        public async Task<IActionResult> AddSpecialty(MajorDto request)
        {
            var result = await _subjectService.AddMajor(request);
            if (result == Status.Fail)
                return StatusCode(500);
            return Ok();
        }
        /// <summary>
        /// Gets a major
        /// </summary>
        [HttpGet("major")]
        public async Task<IActionResult> GetSpecialties(MajorDto request)
        {
            var result = await _subjectService.GetMajor(request);
            if (result == Status.Fail)
                return StatusCode(500);
            return Ok();
        }        
        /// <summary>
        /// Gets a faculty
        /// </summary>
        [HttpGet("faculty")]
        public async Task<IActionResult> GetFaculties(int facultyId)
        {   
            var result = await _subjectService.GetFaculty(facultyId);
            if (result == null)
                return StatusCode(500);
            return Ok(result.Specialties);
        }
        /// <summary>
        /// Gets a list of subjects
        /// </summary>
        [HttpGet("subjects")]
        public async Task<IActionResult> GetSubjects()
        {
            var result = await _subjectService.GetAllSubjects();
            if (result == null || result.Count == 0  )
                return StatusCode(500);
            return Ok(result);
        }
        /// <summary>
        /// Gets a list of majors 
        /// </summary>
        [HttpGet("majors")]
        public async Task<IActionResult> GetSpecialties()
        {
            var result = await _subjectService.GetAllMajors();
            if (result == null || result.Count == 0  )
                return StatusCode(500);
            return Ok(result);
        }
        /// <summary>
        /// Gets a list of faculties
        /// </summary>
        [HttpGet("faculties")]
        public async Task<IActionResult> GetFaculties()
        {
            var result = await _subjectService.GetAllFaculties();
            if (result == null || result.Count == 0  )
                return StatusCode(500);
            return Ok(result);
        }
    }
}
