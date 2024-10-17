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
        /// <summary>
        /// Redirect to Create Page of Movie
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Redirect to Edit Page of Movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            var editedItems = Movies.FirstOrDefault(x => x.ID == id);
            return View(editedItems); 
        }
        /// <summary>
        /// Redirect to Delete Page of Movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            var deletedItems = Movies.FirstOrDefault(x => x.ID == id);
            if (deletedItems is null)
            {
                return NotFound(); //If can't find the Movie->Blank page
            }
            return View(deletedItems); //Redirect to Delete page of Movie
        }
        /// <summary>
        /// Append Movies
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IActionResult AddMovie(Movie item)
        {
            item.ID = Movies.Any() ? Movies.Last().ID : 1;
            Movies.Add(item);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Edit movies
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IActionResult EditMovie(Movie item)
        {
            var editedItems = Movies.FirstOrDefault(x => x.ID == item.ID);
            if (editedItems is not null)
            {
                editedItems.Title = item.Title;                 //Set edited values
                editedItems.Genre = item.Genre;                 //Set edited values
                editedItems.ReleaseYear = item.ReleaseYear;     //Set edited values
            }

            return RedirectToAction("Index");
        }
        /// <summary>
        /// Delete movies through a HttpPostRequest
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteMovie(int id)
        {
            var deletedItems = Movies.FirstOrDefault(x => x.ID == id);
            if (deletedItems is not null)
            {
                Movies.Remove(deletedItems);        //Remove the selected Movie from List
            }
            return RedirectToAction("Index");
        }
    }
}
