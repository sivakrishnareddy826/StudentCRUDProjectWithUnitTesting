using StudentProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProjectTest.MockData
{
    public class StudentMockData
    {
        public static IEnumerable<Student> GetAllStudents()
        {
            return new List<Student>()
            {
                new Student { Id = 1,Name="Siva",Email="Siva@gmail.com",Phone=9876543210,Address="AKP"},
                new Student { Id = 2,Name="Siva12",Email="siva12@gmail.com",Phone=9876543120,Address="AKPl"},
            };
        }
    }
}
