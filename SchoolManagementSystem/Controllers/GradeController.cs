using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using SchoolManagementSystem.Data;
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
        private readonly IDataBundlingService _bundlingService;
        public GradeController(IGradingService gradingService, IAuthenticationManager authManager, IDataBundlingService dataBundlingService)
        {
            _gradingService = gradingService;
            _authManager = authManager;
            _bundlingService = dataBundlingService;
        }
        
        [HttpGet("student")] 
        [Authorize(Roles="Student,Admin")]
        public async Task<ActionResult<GradeDto>> GetStudentGrades()
        {
            var userCredentials = _authManager.ParseToken(HttpContext.Request.Cookies["token"]);
            if (userCredentials == null)
                return StatusCode(502);
            int studentId = int.Parse(userCredentials["id"]);

            var grades = await _bundlingService.OrganizeStudentGradeData(studentId);
          if(grades == null)
              return StatusCode(418); //¯\_(ツ)_/¯   

          return Ok(grades);
        }
        [HttpGet("subjects-with-grades")]
        [Authorize(Roles="Student,Admin")]
        public async Task<ActionResult<Dictionary<string, List<GradeResultDto>>>> GetStudentGradesAndSubjects()
        {
            var userCredentials = _authManager.ParseToken(HttpContext.Request.Cookies["token"]);
            if (userCredentials == null)
                return StatusCode(502);
            int studentId = int.Parse(userCredentials["id"]);

            var grades = await _bundlingService.OrganizeGradesPerSubjects(studentId);
            if(grades == null)
                return StatusCode(418); //¯\_(ツ)_/¯   

            return Ok(grades);
        }
        [HttpGet("teacher")] 
        [Authorize(Roles="Teacher,Admin")]
        public async Task<ActionResult<GradeDto>> GetTeacherGrades()
        {
            var userCredentials = _authManager.ParseToken(HttpContext.Request.Cookies["token"]);
            if (userCredentials == null)
                return StatusCode(502);
            int teacherId = int.Parse(userCredentials["id"]);

            var grades = await _bundlingService.OrganizeTeacherGradeData(teacherId);
            if(grades == null)
                return StatusCode(418); //¯\_(ツ)_/¯

            return Ok(grades);
        }
        [HttpPost]
        public async Task<ActionResult<Grade>> AddGrade(GradeDto request)
        {
            var status = await _gradingService.AddGrade(request); 
            
            if(status == Status.Fail)
              return StatusCode(418); //¯\_(ツ)_/¯
            
            return Ok("Grade added successfully");
        }
        // DELETE: api/Teacher/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var status = await _gradingService.DeleteGrade(id);
            if(status == Status.Fail)
                return StatusCode(418); //¯\_(ツ)_/¯

            return Ok();
        }
    }
}
