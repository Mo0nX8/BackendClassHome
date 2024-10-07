using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace VBJ._13B.Group1.WebApp.Controllers
{
    // MVC Controller -> : Controller - >Controller oszt�ly (ASP fejleszt�k �rt�k) lesz�rmazottja
    // �s oszt�ly -> minden protected �s public tagot el�r�nk
    public class HomeController : Controller
    {
        // Home View-k k�z�tti, Index.cshtml-t adja vissza
        // Met�dus megk�ti a View nev�t
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
