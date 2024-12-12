
using ContosoUniversityYanShapovalov12.Models;

namespace ContosoUniversityYanShapovalov12.Data
{
    public class Dbinitializer
    {
        public static void Initialize(SchoolContext context)

        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student {FirstMiddleName="Yan" , LastName="Shapovalov", EnrollmentDate=DateTime.Parse

                ("2099-09-29")}
            };

        }
    }
}
