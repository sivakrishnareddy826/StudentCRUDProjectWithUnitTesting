using StudentProject.Models;

namespace StudentProject.Repository
{
    public interface IStudent
    {
         IEnumerable<Student> GetStudents();
         Student GetStudent(int id);
         void AddStudent(Student student);
         void UpdateStudent(Student student);
         void DeleteStudent(int id);

    }
}
