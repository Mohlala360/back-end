using System;

namespace ControllerApp.Domains.Cars
{
    public class CarBookState
    {
        public int CarBookStateId { get; set; }
        public int CarBookStatusId { get; set; }
        public int CarBookingId { get; set; }
        public virtual CarBooking CarBooking { get; set; }
        public virtual CarBookStatus CarBookStatus { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
