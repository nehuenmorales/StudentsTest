using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestBackend.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    DocumentType = table.Column<int>(type: "int", nullable: true),
                    Passport = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "DocumentType", "Email", "Name", "Passport", "Phone", "Surname" },
                values: new object[,]
                {
                    { 1, 1, "juan@gmail.com", "Juan", "87049862Z", null, "Garcia Garcia" },
                    { 2, 1, "pedro@gmail.com", "Pedro", "36289717H", null, "Gonzalez Gonzales" },
                    { 3, 2, "antonio@gmail.com", "Antonio", "444444444A", "677777775", "Diaz Diaz" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
