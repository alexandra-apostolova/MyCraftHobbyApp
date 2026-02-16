using Microsoft.AspNetCore.Mvc;

namespace MyCraftHobbyApp.Controllers
{
    public class MyProjects : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
