namespace DotNetApplication.Data
{
    public class Course
    {
        public int courseId { get; set; }
        public string courseName { get; set; }

        public string courseDescription { get; set; }

        public ICollection<Enrollement>? Enrollements { get; set; }
    }
}
