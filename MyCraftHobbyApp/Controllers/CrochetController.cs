using Microsoft.AspNetCore.Mvc;

namespace MyCraftHobbyApp.Controllers
{
    public class CrochetController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
