using System.ComponentModel;

namespace TestBackend.Entities
{
    public class Students
    {
        public int StudentId { get; set; }
        public string? Name { get; set; } 
        public string? Surname { get; set; } 
        public DocumentType? DocumentType { get; set; }
        public string? Passport { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

    }

    public enum DocumentType
    {
        [Description("DNI")]
        DNI = 1,
        [Description("Passport")]
        Passport = 2
    }
}
