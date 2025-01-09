﻿using ContosoUniversityYanShapovalov12.Data;
using ContosoUniversityYanShapovalov12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversityYanShapovalov12.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());

        }
        /*
            public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber
            )
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParam"] = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["currentFilter"] = searchString;
            var students = from student in _context.Students
                           select student;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(student =>
                student.LastName.Contains(searchString) ||
                student.FirstMidName.Contains(searchString));
            }
            switch (sortOrder) 
            {
                case "name_desc":
                    students = students.OrderByDescending(student => student.LastName);
                case "firstname_desc":
                    students = students.OrderByDescending(student => student.FirstMiddleName);
                case "Date":
                    students = students.OrderBy(student => student.EnrollmentDate);
                case "name_desc":
                    students = students.OrderByDescending(student => student.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(student => student.LastName);
                    break;
            }
            int pageSize = 3;
            return View(await _context.Students.ToListAsync);
        }  
    
        public IActionResult Create()
        {
            return View();
        }
        */

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync();

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        private bool StudentExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Clone(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            var ClonedStudent = new Student
            {
                LastName = student.LastName,
                FirstMiddleName = student.FirstMiddleName,
                EnrollmentDate = student.EnrollmentDate,
            };
            _context.Students.Add(ClonedStudent);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AssignGrade()
        {
            ViewBag.Students = new SelectList(_context.Students, "ID", "FullName");
            ViewBag.Courses = new SelectList(_context.Courses, "CourseID", "Title");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignGrade(int studentID, int courseID, Grade? grade)
        {
            if (studentID == 0 || courseID == 0 || grade == null)
            {
                ModelState.AddModelError("", "All fields are required.");
                return View();
            }

            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(e => e.StudentID == studentID && e.CourseID == courseID);

            if (enrollment == null)
            {
                ModelState.AddModelError("", "Enrollment not found for this student and course.");
                return View();
            }

            enrollment.Grade = grade;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }




    }
}
