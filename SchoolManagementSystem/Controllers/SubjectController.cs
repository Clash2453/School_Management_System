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
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(SubjectDto request)
        {
            return Ok(await _subjectService.CreateSubject(request));
        }

        // DELETE: api/Subject/5
        [HttpDelete]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            return Ok(await _subjectService.RemoveSubject(id));
        }
        [HttpPost("add-faculty")]
        public async Task<IActionResult> AddFaculty(FacultyDto request)
        {
            var result = await _subjectService.AddFaculty(request);
            if (result == Status.Fail)
                return StatusCode(500);
            return Ok();
        }
        [HttpPost("add-specialty")]
        public async Task<IActionResult> AddSpecialty(SpecialtyDto request)
        {
            var result = await _subjectService.AddSpecialty(request);
            if (result == Status.Fail)
                return StatusCode(500);
            return Ok();
        }
        [HttpGet("get-specialty")]
        public async Task<IActionResult> GetSpecialties(SpecialtyDto request)
        {
            var result = await _subjectService.GetSpecialty(request);
            if (result == Status.Fail)
                return StatusCode(500);
            return Ok();
        }
        [HttpGet("get-faculty")]
        public async Task<IActionResult> GetFaculties(int facultyId)
        {   
            var result = await _subjectService.GetFaculty(facultyId);
            if (result == null)
                return StatusCode(500);
            return Ok(result.Specialties);
        }

        [HttpGet("get-subjects")]
        public async Task<IActionResult> GetSubjects()
        {
            var result = await _subjectService.GetAllSubjects();
            if (result == null || result.Count == 0  )
                return StatusCode(500);
            return Ok(result);
        }
        [HttpGet("get-specialties")]
        public async Task<IActionResult> GetSpecialties()
        {
            var result = await _subjectService.GetAllSpecialties();
            if (result == null || result.Count == 0  )
                return StatusCode(500);
            return Ok(result);
        }
        [HttpGet("get-faculties")]
        public async Task<IActionResult> GetFaculties()
        {
            var result = await _subjectService.GetAllFaculties();
            if (result == null || result.Count == 0  )
                return StatusCode(500);
            return Ok(result);
        }
    }
}
