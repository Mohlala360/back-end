using ControllerApp.Domains.Users;
using System;
using System.Collections.Generic;

namespace ControllerApp.Domains.Cars
{
    public class CarBooking
    {
        public int CarBookingId { get; set; }
        public string BookingReason { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime BookingFrom { get; set; }
        public DateTime BookingTo { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual Car Car { get; set; }
        public int CarId { get; set; }
        public DateTime DateCaptured { get; set; }
        public int UserCatured { get; set; }
        public virtual ICollection<CarBookState> CarBookStates { get; set; }
    }
}
