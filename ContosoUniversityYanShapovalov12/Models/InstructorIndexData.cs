﻿using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversityYanShapovalov12.Models
{
    public class InstructorIndexData : Controller
    {
        public IEnumerable<Instructor> Instructors { get; set; }

        public IEnumerable<Course> Courses { get; set; }

        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
