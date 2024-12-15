using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestBackend.Context;
using TestBackend.DTOs;
using TestBackend.Entities;

namespace TestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentsDTO>>> Get()
        {
            var listDTO = new List<StudentsDTO>();
            var listDB = await _context.Students.ToListAsync();

            foreach (var item in listDB)
            {

                listDTO.Add(new StudentsDTO
                {
                    StudentId = item.StudentId,
                    Name = item.Name,
                    Surname = item.Surname,
                    DocumentType = item.DocumentType,
                    Passport = item.Passport,
                    Email = item.Email,
                    Phone = item.Phone
                });
            }

            return Ok(listDTO);
        }

        [HttpGet("{StudentId}")]
        public async Task<ActionResult<StudentsDTO>> Get(int StudentId)
        {
            var studentDTO = new StudentsDTO();
            var studentDB = await _context.Students.FindAsync(StudentId);

            if (studentDB is null) return NotFound("Student not found");

            studentDTO.StudentId = StudentId;
            studentDTO.Name = studentDB.Name;
            studentDTO.Surname = studentDB.Surname;
            studentDTO.DocumentType = studentDB.DocumentType;
            studentDTO.Passport = studentDB.Passport;
            studentDTO.Email = studentDB.Email;
            studentDTO.Phone = studentDB.Phone;

            return Ok(studentDTO);
        }

        [HttpPost]
        public async Task<ActionResult<StudentsDTO>> Save(StudentsDTO studentDTO)
        {

            var StudentDB = new Students
            {
                Name = studentDTO.Name,
                Surname = studentDTO.Surname,
                DocumentType = studentDTO.DocumentType,
                Passport = studentDTO.Passport,
                Email = studentDTO.Email,
                Phone = studentDTO.Phone,
            };

            await _context.Students.AddAsync(StudentDB);
            await _context.SaveChangesAsync();
            return Ok("Save succes");

        }

        [HttpPut]
        public async Task<ActionResult<StudentsDTO>> Update(StudentsDTO studentDTO)
        {
            var studentDB = await _context.Students.Where(s => s.StudentId == studentDTO.StudentId).FirstAsync();

            if(studentDB is null) return NotFound("Student not found");

            studentDB.Name = studentDTO.Name;
            studentDB.Surname = studentDTO.Surname;
            studentDB.DocumentType = studentDTO.DocumentType;
            studentDB.Passport = studentDTO.Passport;
            studentDB.Email = studentDTO.Email;
            studentDB.Phone = studentDTO.Phone;

            _context.Students.Update(studentDB);
            await _context.SaveChangesAsync();
            return Ok("Edit succes");

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentsDTO>> Delete(int id)
        {
            var studentDB = await _context.Students.FindAsync(id);

            if (studentDB is null) return NotFound("Student not found");

            _context.Students.Remove(studentDB);
            await _context.SaveChangesAsync();

            return Ok("Student deleted");
        }
    }
}
