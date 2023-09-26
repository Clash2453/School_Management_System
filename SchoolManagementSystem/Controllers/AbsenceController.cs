using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceController : ControllerBase
    {
        private readonly IAbsenceService _absenceService;
        public AbsenceController(IAbsenceService absenceService)
        {
            _absenceService = absenceService;
        }
        
        [HttpGet("absences")]
        public async Task<ActionResult<IEnumerable<Absence>>> GetAbsenceById(int id)
        {
            var absence = await _absenceService.GetAbsenceById(id);
            if (absence == null)
                return NotFound();
            
            return Ok(absence);
        }
        
        [HttpGet("absenceBy/id/student")]
        public async Task<ActionResult<List<Absence>>> GetAbsenceByStudent(int id)
        {
            return Ok(await _absenceService.GetAbsenceByStudent(id));
        }
        [HttpGet("absenceBy/id/teacher")]
        public async Task<ActionResult<List<Absence>>> GetAbsenceByTeacher(int id)
        {
            return Ok(await _absenceService.GetAbsenceByTeacher(id));
        }
        [HttpPut("absences")]
        public async Task<IActionResult> ExcuseAbsences(int subjectId, DateTime date, int studentId)
        {
            var task = await _absenceService.ExcuseAbsences(studentId, subjectId, date);
            if (task == Status.Fail)
                return NotFound();

            return Ok();
        }
        
        [HttpPost("absences")]
        public async Task<ActionResult<Absence>> PostAbsence(AbsenceDto request)
        {
            var task = await _absenceService.CreateAbsence(request);

            if (task == Status.Fail)
                return StatusCode(502);

            return Ok("Successfully created");
        }
        
        [HttpDelete("absences")]
        public async Task<IActionResult> DeleteAbsence(int id)
        {
            var task = await _absenceService.RemoveAbsenceById(id);
            if (task == Status.Fail)
                return StatusCode(404);
            return Ok("Entry removed");
        }
    }
}
