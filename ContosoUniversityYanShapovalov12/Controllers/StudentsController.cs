using ContosoUniversityYanShapovalov12.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversityYanShapovalov12.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _schoolContext;

        public StudentsController(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _schoolContext.Students.ToListAsync();

            return View(result);
        }
    }
}
