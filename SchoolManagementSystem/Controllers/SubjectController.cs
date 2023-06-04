using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
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

        // GET: api/Subject
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        // {
        // }

        // GET: api/Subject/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Subject>> GetSubject(int id)
        // {
        // }

        // PUT: api/Subject/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut]
        // public async Task<IActionResult> PutSubject(int id, Subject subject)
        // {
        //     
        // }

        // POST: api/Subject
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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
        public async Task<IActionResult> GetSpecialty(SpecialtyDto request)
        {
            var result = await _subjectService.GetSpecialty(request);
            if (result == Status.Fail)
                return StatusCode(500);
            return Ok();
        }
        [HttpGet("get-faculty")]
        public async Task<IActionResult> GetFaculty(int facultyId)
        {
            var result = await _subjectService.GetFaculty(facultyId);
            if (result == null)
                return StatusCode(500);
            return Ok(result.Specialties);
        }
    }
}
