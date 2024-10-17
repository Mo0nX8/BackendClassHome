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
        public IActionResult BookRoom(int id)
        {
            var room = Rooms.FirstOrDefault(x => x.ID == id);
            if (room is null)
            {
                return NotFound();
            }
            var viewModel = new viewModelRoomBooking
            {
                roomView = room,
                bookingView = new Booking() { RoomID = room.ID }
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Book(viewModelRoomBooking item)
        {
            var room = Rooms.FirstOrDefault(x => x.ID == item.roomView.ID);
            if (room is null)
            {
                return NotFound();
            }

            room.IsAvailable = false;
            Bookings.Add(new Booking
            {
                CustomerName = item.bookingView.CustomerName,
                BookDate = DateTime.Now.Date,
                RoomID = item.bookingView.RoomID,
            });

            return RedirectToAction("Index");
        }
    }
}
