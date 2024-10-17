using Microsoft.AspNetCore.Mvc;

namespace VBJ._13B.Group1.WebApp.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
