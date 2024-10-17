using Microsoft.AspNetCore.Mvc;
using VBJ._13B.Group1.WebApp.Models;

namespace VBJ._13B.Group1.WebApp.Controllers
{
    public class StudentController : Controller
    {
        /// <summary>
        /// Stores the students
        /// </summary>
        private readonly static List<Student> studentsList = new List<Student>(); 
        public IActionResult Index()
        {
            return View(studentsList);
        }
        /// <summary>
        /// Redirect to Register page
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// Append List with new student, set ID and Date
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IActionResult AddStudent(Student item)
        {
            item.ID = studentsList.Any() ? studentsList.Last().ID : 1;
            item.date = DateTime.Now.Date;
            studentsList.Add(item);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Delete a defined student from the List
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            var deletedItems = studentsList.FirstOrDefault(x => x.ID == id);
            if (deletedItems != null)
            {
                studentsList.Remove(deletedItems);
            }
            return RedirectToAction("Index");
        }

    }
}
