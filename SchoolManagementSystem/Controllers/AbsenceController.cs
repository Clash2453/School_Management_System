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
        
        [HttpGet("absenceBy/id")]
        public async Task<ActionResult<IEnumerable<Absence>>> GetAbsenceById(int id)
        {
            var absence = await _absenceService.GetAbsenceById(id);
            if (absence == null)
                return NotFound();
            
            return Ok(absence);
        }
        
        [HttpGet("absenceBy/studentId")]
        public async Task<ActionResult<List<Absence>>> GetAbsenceByStudent(int id)
        {
            return Ok(await _absenceService.GetAbsenceByStudent(id));
        }
        [HttpGet("absenceBy/teacherId")]
        public async Task<ActionResult<List<Absence>>> GetAbsenceByTeacher(int id)
        {
            return Ok(await _absenceService.GetAbsenceByTeacher(id));
        }
        [HttpPut("excuse/absence")]
        public async Task<IActionResult> ExcuseAbsence(int id)
        {
            var task = await _absenceService.ExcuseAbsenceById(id);
            if (task == Status.Fail)
                return NotFound();

            return Ok();
        }
        
        [HttpPut("excuse/absences")]
        public async Task<IActionResult> ExcuseAbsences(int subjectId, DateTime date, int studentId)
        {
            var task = await _absenceService.ExcuseAbsences(studentId, subjectId, date);
            if (task == Status.Fail)
                return NotFound();

            return Ok();
        }
        
        [HttpPost]
        public async Task<ActionResult<Absence>> PostAbsence(AbsenceDto request)
        {
            var task = await _absenceService.CreateAbsence(request);

            if (task == Status.Fail)
                return StatusCode(502);

            return Ok("Successfully created");
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteAbsence(int id)
        {
            var task = await _absenceService.RemoveAbsenceById(id);
            if (task == Status.Fail)
                return StatusCode(404);
            return Ok("Entry removed");
        }
    }
}
