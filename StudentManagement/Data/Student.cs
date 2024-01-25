namespace DotNetApplication.Data
{
    public class Student
    {
        public int studentId { get; set; }

        public string StudentName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public DateTime DOB { get; set; }

        public ICollection<Enrollement>? Enrollements { get; set; }
    }
}
