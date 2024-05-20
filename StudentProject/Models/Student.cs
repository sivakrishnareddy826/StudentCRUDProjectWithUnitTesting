namespace StudentProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
