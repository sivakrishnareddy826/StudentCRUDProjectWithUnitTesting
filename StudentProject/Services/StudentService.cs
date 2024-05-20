using MySql.Data.MySqlClient;
using StudentProject.Models;
using StudentProject.Repository;

namespace StudentProject.Services
{
    public class StudentService : IStudent
    {
        public readonly StudentDbContext _studentDbContext;
        public StudentService(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }
        public void AddStudent(Student student)
        {
            using(MySqlConnection connection = _studentDbContext.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO student(student_name,student_email,student_phone,student_address)VALUES(@Name,@Email,@Phone,@Address)";

                using(MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Email", student.Email);
                    command.Parameters.AddWithValue("@Phone", student.Phone);
                    command.Parameters.AddWithValue("@Address", student.Address);

                    command.ExecuteNonQuery();
                }
            }
        }



        public Student GetStudent(int id)
        {
            using (MySqlConnection connection = _studentDbContext.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM student WHERE student_id = @Id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Student
                            {
                                Id = Convert.ToInt32(reader["student_id"]),
                                Name = reader["student_name"].ToString(),
                                Email = reader["student_email"].ToString(),
                                Phone = Convert.ToInt64(reader["student_phone"]),
                                Address = reader["student_address"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }


        public IEnumerable<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            using (MySqlConnection connection = _studentDbContext.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM student";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            Id = Convert.ToInt32(reader["student_id"]),
                            Name = reader["student_name"].ToString(),
                            Email = reader["student_email"].ToString(),
                            Phone = Convert.ToInt64(reader["student_phone"]),
                            Address = reader["student_address"].ToString()
                        });
                    }
                }
            }

            return students;
        }

        public void UpdateStudent(Student student)
        {
            using (MySqlConnection connection = _studentDbContext.GetConnection())
            {
                connection.Open();
                string query = "UPDATE student SET student_name = @Name, student_email = @Email, student_phone = @Phone, student_address = @Address WHERE student_id = @Id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", student.Id);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Email", student.Email);
                    command.Parameters.AddWithValue("@Phone", student.Phone);
                    command.Parameters.AddWithValue("@Address", student.Address);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteStudent(int id)
        {
            using (MySqlConnection connection = _studentDbContext.GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM student WHERE student_id = @Id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
