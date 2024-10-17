namespace VBJ._13B.Group1.WebApp.Models
{ /// <summary>
/// Stores the Booked room's properties
/// </summary>
    public class Booking
    {
        public string CustomerName { get; set; }
        public int RoomID { get; set; }
        public DateTime BookDate { get; set; }
    }
}
