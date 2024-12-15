using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TestBackend.Context;
using TestBackend.DTOs;
using TestBackend.Entities;
using TestBackend.Services.Interfaces;



namespace TestBackend.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly AppDbContext _context;
        public StudentsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentsDTO>> GetAllAsync()
        {
            var listDB = await _context.Students.ToListAsync();
            return listDB.Select(student => new StudentsDTO
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Surname = student.Surname,
                DocumentType = student.DocumentType,
                Passport = student.Passport,
                Email = student.Email,
                Phone = student.Phone
            }).ToList();
        }

        public async Task<StudentsDTO> GetByIdAsync(int studentId)
        {
            var studentDB = await _context.Students.FindAsync(studentId);
            if (studentDB == null) return null;

            return new StudentsDTO
            {
                StudentId = studentDB.StudentId,
                Name = studentDB.Name,
                Surname = studentDB.Surname,
                DocumentType = studentDB.DocumentType,
                Passport = studentDB.Passport,
                Email = studentDB.Email,
                Phone = studentDB.Phone
            };
        }

        public async Task<bool> CreateAsync(StudentsDTO studentDTO)
        {
            var student = new Students
            {
                Name = studentDTO.Name,
                Surname = studentDTO.Surname,
                DocumentType = studentDTO.DocumentType,
                Passport = studentDTO.Passport,
                Email = studentDTO.Email,
                Phone = studentDTO.Phone
            };

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(StudentsDTO studentDTO)
        {
            var studentDB = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == studentDTO.StudentId);
            if (studentDB == null) return false;

            studentDB.Name = studentDTO.Name;
            studentDB.Surname = studentDTO.Surname;
            studentDB.DocumentType = studentDTO.DocumentType;
            studentDB.Passport = studentDTO.Passport;
            studentDB.Email = studentDTO.Email;
            studentDB.Phone = studentDTO.Phone;

            _context.Students.Update(studentDB);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int studentId)
        {
            var studentDB = await _context.Students.FindAsync(studentId);
            if (studentDB == null) return false;

            _context.Students.Remove(studentDB);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
