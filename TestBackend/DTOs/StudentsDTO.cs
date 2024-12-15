using TestBackend.Entities;

namespace TestBackend.DTOs
{
    public class StudentsDTO
    {
        public int? StudentId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DocumentType? DocumentType { get; set; }
        public string? Passport { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
