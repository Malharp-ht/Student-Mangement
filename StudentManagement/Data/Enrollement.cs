namespace DotNetApplication.Data
{
    public class Enrollement
    {
        public int enrollementId { get; set; }
        public int studentId { get; set; }
        public int courseId { get; set; }

        //public int? StudentId {  get; set; }
        //public virtual ICollection<Student> Students { get; set; }
        // public virtual Course? Course { get; set; }
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}
