
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

                ("2099-09-29")},
                new Student {FirstMiddleName="Allan" , LastName="Lond", EnrollmentDate=DateTime.Parse

                ("2092-02-29")},
                new Student {FirstMiddleName="Artjem" , LastName="Skatskov", EnrollmentDate=DateTime.Parse

                ("2093-03-29")},
                new Student {FirstMiddleName="Marko" , LastName="Vassiljev", EnrollmentDate=DateTime.Parse

                ("2094-04-29")},
                new Student {FirstMiddleName="Matis" , LastName="Rannaveer", EnrollmentDate=DateTime.Parse

                ("2095-05-29")},
                new Student {FirstMiddleName="Tanno" , LastName="Valk", EnrollmentDate=DateTime.Parse

                ("2096-06-29")},
                new Student {FirstMiddleName="Urmas" , LastName="Tamm", EnrollmentDate=DateTime.Parse

                ("2097-07-29")},
                new Student {FirstMiddleName="Souen" , LastName="Paju", EnrollmentDate=DateTime.Parse

                ("2098-08-29")},
                new Student {FirstMiddleName="Ruuben" , LastName="Rosin", EnrollmentDate=DateTime.Parse

                ("2091-01-29")},
              
            };
            foreach (Student student in students) 
            {
                context.Students.Add(student); 
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course { CourseID = 9001, Title = "Geograafia", Credits = 1 },
                new Course { CourseID = 8002, Title = "Eesti keel", Credits = 2 },
                new Course { CourseID = 7003, Title = "Multimeedia", Credits = 3 },
                new Course { CourseID = 6004, Title = "Bioloogia", Credits = 4 },
                new Course { CourseID = 5005, Title = "Keemia", Credits = 5 },
                new Course { CourseID = 4006, Title = "Programeerimine", Credits = 6 },
                new Course { CourseID = 3007, Title = "Füüsika", Credits = 7 },
                new Course { CourseID = 2008, Title = "Inglise keel", Credits = 8 }
            };
            foreach (Course course in courses) 
            {
                context.Courses.Add(course);
            }
            context.SaveChanges();
            var enrollment = new Enrollment[]
            {

                new Enrollment{StudentID=1,CourseID=1150,Grade=Grade.D},
                new Enrollment{StudentID=1,CourseID=4902,Grade=Grade.C},
                new Enrollment{StudentID=1,CourseID=4751,Grade=Grade.A},
                new Enrollment{StudentID=2,CourseID=4345,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
                new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.E},
                new Enrollment{StudentID=3,CourseID=1520},
                new Enrollment{StudentID=4,CourseID=1340},
                new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
                new Enrollment{StudentID=5,CourseID=4233,Grade=Grade.C},
                new Enrollment{StudentID=6,CourseID=1045},
                new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.B},
                new Enrollment{StudentID=10,CourseID=6501,Grade=Grade.A},
            };
            foreach(Enrollment enrollment in enrollments) 
            {
                context.Enrollments.Add(enrollment);
            }
            context.SaveChanges();

            if (context.Instructors.Any()) { return; }
            var instructors = new Instructor[]
            {
                new Instructor
                {
                    LastName = "Guy",
                    FirstMidName = "Shirt",
                    HireDate = DateTime.Parse("2069-04-20"),
                },
            };
            context.Instructors.AddRange(instructors);
            context.SaveChanges();

            if (context.Departments.Any()) { return; }
            var departments = new Department[]
                {
                new Department
                {
                    Name = "IT",
                    Budget = 0,
                    StartDate = DateTime.Parse("2024-09-01"),
                    InstructorId = 1,
                    Aadress = "Pae 25",
                },
                new Department
                {
                    Name = "English",
                    Budget = 1000,
                    StartDate = DateTime.Parse("2024-08-02"),
                    InstructorId = 2,
                    Aadress = "Pae 14"
                },
            };
            context.Departments.AddRange(departments);
            context.SaveChanges();
        }
    }
}
