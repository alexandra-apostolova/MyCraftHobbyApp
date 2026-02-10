using Microsoft.AspNetCore.Mvc;

namespace MyCraftHobbyApp.Controllers
{
    public class KnitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
