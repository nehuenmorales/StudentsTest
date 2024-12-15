using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestBackend.Context;
using TestBackend.DTOs;
using TestBackend.Entities;
using TestBackend.Services.Interfaces;

namespace TestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentsDTO>>> Get()
        {
            var students = await _studentsService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult<StudentsDTO>> GetById(int studentId)
        {
            var student = await _studentsService.GetByIdAsync(studentId);
            if (student == null) return NotFound("Student not found");

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult> Save(StudentsDTO studentDTO)
        {
            var success = await _studentsService.CreateAsync(studentDTO);
            if (!success) return BadRequest("Failed to save student");

            return Ok("Save success");
        }

        [HttpPut]
        public async Task<ActionResult> Update(StudentsDTO studentDTO)
        {
            var success = await _studentsService.UpdateAsync(studentDTO);
            if (!success) return NotFound("Student not found");

            return Ok("Edit success");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _studentsService.DeleteAsync(id);
            if (!success) return NotFound("Student not found");

            return Ok("Student deleted");
        }
    }
}
