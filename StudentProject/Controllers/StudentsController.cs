using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentProject.Models;
using StudentProject.Repository;

namespace StudentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudent _repository;

        public StudentsController(IStudent repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            IEnumerable<Student> students = _repository.GetStudents();
            return Ok(students);
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _repository.AddStudent(student);

            return Ok("Student added");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _repository.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            var existingStudent = _repository.GetStudent(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            student.Id = id;
            _repository.UpdateStudent(student);
            return Ok("Student updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var existingStudent = _repository.GetStudent(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            _repository.DeleteStudent(id);
            return Ok();
        }

    }
}
