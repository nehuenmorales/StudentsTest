using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBackend.Context;
using TestBackend.DTOs;
using TestBackend.Entities;
using TestBackend.Services;

namespace TestBackendTests.Services
{
    public class StudentsTest
    {

        [Fact]
        public async Task GetAllStudents_ShouldReturnStudents()
        {
            // Arrange
            var context = DbContextInMemory.Create();

            var service = new StudentsService(context);

            // Act
            var students = await service.GetAllAsync();

            // Assert
            Assert.NotNull(students);
            Assert.Equal(3, students.Count);
        }


        [Fact]
        public async Task GetStudentById_ShouldReturnStudent_WhenExists()
        {
            // Arrange
            var context = DbContextInMemory.Create();

            var service = new StudentsService(context);

            // Act
            var result = await service.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Juan", result.Name);
        }

        [Fact]
        public async Task GetStudentById_ShouldReturnNull_WhenNotExists()
        {
            // Arrange
            var context = DbContextInMemory.Create();

            var service = new StudentsService(context);

            // Act
            var result = await service.GetByIdAsync(99);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task AddStudent_ShouldIncreaseCount()
        {
            // Arrange
            var context = DbContextInMemory.Create();
            var service = new StudentsService(context);

            // Act
            await service.CreateAsync(new StudentsDTO
            {
                Name = "Luis",
                Surname = "Ramirez",
                DocumentType = TestBackend.Entities.DocumentType.DNI,
                Passport = "123456789",
                Email = "luis@gmail.com",
                Phone = "555123456"
            });
            var students = await service.GetAllAsync();

            // Assert
            Assert.Equal(4, students.Count); 
        }

        [Fact]
        public async Task DeleteStudent_ShouldRemoveStudentFromDatabase()
        {
            // Arrange
            var context = DbContextInMemory.Create();
            var service = new StudentsService(context);

            // Act
            var initialCount = await context.Students.CountAsync();

            var result = await service.DeleteAsync(1);

            var finalCount = await context.Students.CountAsync();

            // Assert
            Assert.True(result);
            Assert.Equal(initialCount - 1, finalCount);
            Assert.Null(await context.Students.FindAsync(1));
        }

        [Fact]
        public async Task DeleteStudent_ShouldReturnFalseForNonExistentStudent()
        {
            // Arrange
            var context = DbContextInMemory.Create();
            var service = new StudentsService(context);

            // Act
            var result = await service.DeleteAsync(99); 

            // Assert
            Assert.False(result);
        }
    }
}
