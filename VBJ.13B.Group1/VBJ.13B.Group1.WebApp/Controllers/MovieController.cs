using Microsoft.AspNetCore.Mvc;
using VBJ._13B.Group1.WebApp.Models;

namespace VBJ._13B.Group1.WebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly static List<Movie> Movies = new List<Movie>();
        public IActionResult Index()
        {
            return View(Movies);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            var editedItems = Movies.FirstOrDefault(x => x.ID == id);
            return View(editedItems);
        }
    }
}
