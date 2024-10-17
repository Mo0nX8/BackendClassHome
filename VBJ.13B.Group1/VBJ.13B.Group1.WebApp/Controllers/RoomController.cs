using Microsoft.AspNetCore.Mvc;
using VBJ._13B.Group1.WebApp.Models;

namespace VBJ._13B.Group1.WebApp.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View(Rooms);
        }
        private static List<Room> Rooms = new List<Room>();
        private static List<Booking> Bookings = new List<Booking>();

        public RoomController()
        {
            if (!Rooms.Any())
            {
                Rooms = new List<Room>
                {
                    new Room() { ID = 1, IsAvailable = true },
                    new Room() { ID = 2, IsAvailable = true },
                    new Room() { ID = 3, IsAvailable = true },
                    new Room() { ID = 4, IsAvailable = true },
                    new Room() { ID = 5, IsAvailable = true }
                };
            }
        }

    }
}
