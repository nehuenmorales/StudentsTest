using TestBackend.DTOs;

namespace TestBackend.Services.Interfaces
{
    public interface IStudentsService
    {
        Task<List<StudentsDTO>> GetAllAsync();
        Task<StudentsDTO> GetByIdAsync(int studentId);
        Task<bool> CreateAsync(StudentsDTO studentDTO);
        Task<bool> UpdateAsync(StudentsDTO studentDTO);
        Task<bool> DeleteAsync(int studentId); 
    }
}
