using Moq;
using NUnit.Framework;
using StudentProject.Models;
using StudentProject.Controllers;
using StudentProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NUnitTestProject.TestController
{
    [TestFixture]
    public class StudentControllersTest
    {
        private StudentsController _studentsController;
        private Mock<IStudent> _studentrepo;
        [SetUp]
        public void Setup()
        {
            _studentrepo = new Mock<IStudent>();
            _studentsController = new StudentsController(_studentrepo.Object);
        }
        [Test]
        public void GetStudents_ReturnOkResult()
        {
            IEnumerable<Student> mockStudents = new List<Student>
            {
                new Student{Id=1, Name="Siva",Email="siva@gmail.com",Address="Akp",Phone=9876543210},
                new Student{Id=2, Name="krishna",Email="krishna@gmail.com",Address="Akp",Phone=9876543219},
                
            };
            _studentrepo.Setup(repo => repo.GetStudents()).Returns(mockStudents);
            // Act
            IActionResult result = _studentsController.GetAllStudents();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
