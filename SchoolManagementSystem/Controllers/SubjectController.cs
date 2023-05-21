using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
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
    }
}
