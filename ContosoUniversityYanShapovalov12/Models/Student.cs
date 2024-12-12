using System.ComponentModel.DataAnnotations;

namespace ContosoUniversityYanShapovalov12.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string FirstMiddleName { get; set; }
        public string LastName { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set;}
        public DateTime EnrollmentDate { get; set; }



    }
}
