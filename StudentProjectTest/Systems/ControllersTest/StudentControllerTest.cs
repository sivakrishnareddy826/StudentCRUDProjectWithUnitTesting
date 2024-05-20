using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentProject.Controllers;
using StudentProject.Models;
using StudentProject.Repository;
using StudentProjectTest.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProjectTest.Systems.ControllersTest
{
    public class StudentControllerTest
    {
        [Fact]
        public void GetStudentsShouldReturn200Status()
        {
            //Arrange
            var studentService = new Mock<IStudent>();
            studentService.Setup(x => x.GetStudents()).Returns(StudentMockData.GetAllStudents());
            var sut = new StudentsController(studentService.Object);//sut stands for System Under Test
            //Act
            var result = sut.GetAllStudents();

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public void GetById_ExistingId_ReturnsOkResult()
        {
            // Arrange
            var studentId = 1;
            var mockRepo = new Mock<IStudent>();
            mockRepo.Setup(repo => repo.GetStudent(studentId))
                .Returns(new Student { Id = studentId, Name = "Test Student" });
            var controller = new StudentsController(mockRepo.Object);

            // Act
            var result = controller.GetById(studentId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var student = Assert.IsAssignableFrom<Student>(okResult.Value);
            Assert.Equal(studentId, student.Id);
        }

        [Fact]
        public void GetById_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            var studentId = 999; // Non-existing ID
            var mockRepo = new Mock<IStudent>();
            mockRepo.Setup(repo => repo.GetStudent(studentId))
                .Returns((Student)null); // Simulate null return for non-existing student
            var controller = new StudentsController(mockRepo.Object);

            // Act
            var result = controller.GetById(studentId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

    }
}
