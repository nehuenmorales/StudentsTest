using Microsoft.EntityFrameworkCore;
using TestBackend.Entities;

namespace TestBackend.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Students> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Students>(tb => {
                tb.HasKey(col => col.StudentId);
                tb.Property(col => col.StudentId).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.Name).HasMaxLength(int.MaxValue);
                tb.Property(col => col.Surname).HasMaxLength(int.MaxValue);
                tb.Property(col => col.DocumentType).HasConversion<int>();
                tb.Property(col => col.Passport).HasMaxLength(int.MaxValue);
                tb.Property(col => col.Email).HasMaxLength(int.MaxValue);
                tb.Property(col => col.Phone).HasMaxLength(int.MaxValue);
                tb.ToTable("Students");
                tb.HasData(
                        new Students
                        {
                            StudentId = 1,
                            Name = "Juan",
                            Surname = "Garcia Garcia",
                            DocumentType = DocumentType.DNI,
                            Passport = "87049862Z",
                            Email = "juan@gmail.com",
                            Phone = null
                        },
                        new Students
                        {
                            StudentId = 2,
                            Name = "Pedro",
                            Surname = "Gonzalez Gonzales",
                            DocumentType = DocumentType.DNI,
                            Passport = "36289717H",
                            Email = "pedro@gmail.com",
                            Phone = null
                        },
                        new Students
                        {
                            StudentId = 3,
                            Name = "Antonio",
                            Surname = "Diaz Diaz",
                            DocumentType = DocumentType.Passport,
                            Passport = "444444444A",
                            Email = "antonio@gmail.com",
                            Phone = "677777775"
                        }
                );
            });

        }



    }
}
