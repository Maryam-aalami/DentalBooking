using Microsoft.AspNetCore.Mvc;

namespace LocalTest.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}