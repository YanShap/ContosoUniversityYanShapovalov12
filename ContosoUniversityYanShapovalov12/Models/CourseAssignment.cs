using System.ComponentModel.DataAnnotations;

namespace ContosoUniversityYanShapovalov12.Models
{
    public class CourseAssignment
    {
        [Key]
        public int Id { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}
