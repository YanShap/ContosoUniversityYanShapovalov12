using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversityYanShapovalov12.Controllers
{
    public class InstructorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
