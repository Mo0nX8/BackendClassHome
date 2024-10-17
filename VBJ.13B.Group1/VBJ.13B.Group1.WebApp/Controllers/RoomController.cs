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
        private static List<Room> Rooms = new List<Room>(); //Rooms list
        private static List<Booking> Bookings = new List<Booking>(); //Bookings list

        public RoomController() //Filled up the rooms in the constructor
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
        /// <summary>
        /// Redirect to BookRoom Page while storing data of Room and RoomID for Booking
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult BookRoom(int id)
        {
            var room = Rooms.FirstOrDefault(x => x.ID == id);
            if (room is null)
            {
                return NotFound();   //if room is null it gives blank page
            }
            var viewModel = new viewModelRoomBooking //The model which connect Room and Booking model together
            {
                roomView = room,                //The connector model stores the room's data
                bookingView = new Booking() { RoomID = room.ID } //The connector model stores the roomID for Booking model
            };
            return View(viewModel);  //Load BookRoom with the viewModel
        }
        /// <summary>
        /// Make the booking
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Book(viewModelRoomBooking item) //called when BookRoom page send the PostRequest
        {
            var room = Rooms.FirstOrDefault(x => x.ID == item.roomView.ID); 
            if (room is null)
            {
                return NotFound();  //if room is null it gives blank page
            }

            room.IsAvailable = false;   //Set the room as unavailable
            Bookings.Add(new Booking
            {
                CustomerName = item.bookingView.CustomerName,   //Set Booking model's properties's value
                BookDate = DateTime.Now.Date,                   //-->
                RoomID = item.bookingView.RoomID,               //:
            });

            return RedirectToAction("Index");   //Redirect to index page
        }
    }
}
