using Microsoft.AspNetCore.Mvc;
using VBJ._13B.Group1.WebApp.Models;

namespace VBJ._13B.Group1.WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly static List<Student> studentsList = new List<Student>();
        public IActionResult Index()
        {
            return View(studentsList);
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult AddStudent(Student item)
        {
            item.ID = studentsList.Any() ? studentsList.Last().ID : 1;
            item.date = DateTime.Now.Date;
            studentsList.Add(item);
            return RedirectToAction("Index");
        }

    }
}
