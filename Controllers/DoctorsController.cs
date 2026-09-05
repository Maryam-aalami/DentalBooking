using Microsoft.AspNetCore.Mvc;

namespace LocalTest.Controllers
{
    public class DoctorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}