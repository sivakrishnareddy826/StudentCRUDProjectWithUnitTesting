using MySql.Data.MySqlClient;

namespace StudentProject.Models
{
    public class StudentDbContext
    {
        public readonly string _Connection;

        public StudentDbContext(string Connection)
        {
            this._Connection = Connection;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_Connection);
        }
    }
}
